using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PIIVault.Shared.Models;
using PIIVaultDemoApp.Helpers;
using Newtonsoft.Json;
using PIIVaultDemoApp.Environments;
using System.Linq;
using Teradata.Client.Provider;
using PIIVault.Shared;
using System.IO;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace PIIVaultDemoApp
{
    public partial class FormPassThrough : Form
    {
        private OpenFileDialog fileLoadData;
        private string _dataFile;
        private string _schemaFile;
        private DataTable _dtSchema;
        private DataTable _dtData = new DataTable();
        private DataTable _dtResult;
        private DataTable _dtPolyIds;
        private string _polyIndexName = "PolyAnonymous-Id";
        private string _sourceIndex = "";
        private List<PiiCol> _piiCol = new List<PiiCol>();
        private HttpService _httpService;
        private IEnvironment _environment;
        private readonly frmLogin _frmLogin;
        private IEnumerable<IEnvironment> _environments;
        private string _Token;
        private List<object> _sourceControls = new List<object>();
        private string _sourceType;

        public string WindowMode { get; set; }

        public const string WindowModeMasking = "Masking";
        public const string WindowModeAnonymization = "Anonymization";

        public FormPassThrough()
        {
            InitializeComponent();
            _frmLogin = new frmLogin();

            _environments = EnvironmentFlatFileHandler.GetEnvironments();

            ReloadComboBoxOptions(_environments);
            cboEnvironments.SelectedValueChanged += CboEnvironments_SelectedValueChanged;

            /* load these controls into a list so we can easily show/hide them */
            _sourceControls.Add(gbSource);
            _sourceControls.Add(labelSourceDatabase);
            _sourceControls.Add(labelSourcePassword);
            _sourceControls.Add(labelSourceQuery);
            _sourceControls.Add(labelSourceSource);
            _sourceControls.Add(labelSourceUser);
            _sourceControls.Add(tbSourceDatabase);
            _sourceControls.Add(tbSourcePassword);
            _sourceControls.Add(tbSourceSource);
            _sourceControls.Add(tbSourceSQL);
            _sourceControls.Add(tbSourceUser);

            cbSource.Text= Properties.Settings.Default["SourceType"].ToString();
            string settingFile = Properties.Settings.Default["SourceFilename"].ToString();
            if (!string.IsNullOrEmpty(settingFile))
            {
                LoadSettings(settingFile);
            }
        }

        private void step1LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
            
        {
            try
            {
                tabControl1.SelectTab(tpData);
                switch (_sourceType)
                {
                    case "Teradata":

                        /*  at this point we only support Teradata as a native db interface. */
                        TdConnectionStringBuilder connectionStringBuilder = new TdConnectionStringBuilder();
                        connectionStringBuilder.DataSource = tbSourceSource.Text.Trim();
                        connectionStringBuilder.Database = tbSourceDatabase.Text.Trim();
                        connectionStringBuilder.UserId = tbSourceUser.Text.Trim();
                        connectionStringBuilder.Password = tbSourcePassword.Text.Trim();

                        TdConnection connection = new TdConnection();
                        connection.ConnectionString = connectionStringBuilder.ConnectionString;
                        connection.Open();

                        TdCommand cmd = connection.CreateCommand();
                        cmd.CommandText = tbSourceSQL.Text;

                        _dtData = new DataTable();
                        using (TdDataReader reader = cmd.ExecuteReader())
                        {
                            _dtData.Load(reader);
                            dgvData.DataSource = _dtData;
                            int sourceRecordCount = _dtData.Rows.Count;
                        }

                        /* save the tablename so we can use it to save and restore the schema */
                        string[] pieces = SQLHelper.GetSelectTableName(tbSourceSQL.Text).Split('.');
                        string path = Directory.GetCurrentDirectory();
                        _schemaFile = path + "\\" + pieces[pieces.Length - 1];
                        RestoreSchema();

                        break;

                    case "SQL Server":

                        SqlConnectionStringBuilder builder =   new SqlConnectionStringBuilder();
                        builder["Data Source"] = tbSourceSource.Text.Trim();
                        builder["integrated Security"] = false;
                        builder["Initial Catalog"] = tbSourceDatabase.Text.Trim(); 
                        
                        builder.Password = tbSourcePassword.Text.Trim();
                        builder.UserID = tbSourceUser.Text.Trim();

                        string temp = builder.ConnectionString;

                        SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);
                        sqlConnection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(tbSourceSQL.Text, builder.ConnectionString))
                        {
                            adapter.Fill(_dtData);
                            dgvData.DataSource = _dtData;
                            int sourceRecordCount = _dtData.Rows.Count;
                        }

                        /* save the tablename so we can use it to save and restore the schema */
                        string[] sqlPieces = SQLHelper.GetSelectTableName(tbSourceSQL.Text).Split('.');
                        string sqlPath = Directory.GetCurrentDirectory();
                        _schemaFile = sqlPath + "\\" + sqlPieces[sqlPieces.Length - 1];
                        RestoreSchema();

                        break;

                    default:
                    /*  Open a file open dialog to allow user to select a flat file of new data to load*/
                    fileLoadData = new OpenFileDialog();
                    DialogResult dialog = fileLoadData.ShowDialog();

                    if (dialog == DialogResult.OK)
                    {
                        LoadSourceDataCSV();
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data. Details are: " + ex.ToString());
            }
        }

        private void LoadSourceDataCSV()
        {
            /* Loads the CSV file of data
             * if there is a schema file already associated with this data file, load it too
             */
            try
            {
                _dtData = ReadCSV.GetDataTable(fileLoadData.FileName);
                dgvData.DataSource = new DataTable();
                dgvData.DataSource = _dtData;
                dgvData.DefaultCellStyle.Font = new Font("Calibri", 12);

                _dataFile = fileLoadData.FileName;
                _schemaFile = _dataFile + ".schema";
                RestoreSchema();
            }
            catch (Exception ex)
            {
            }
            tabControl1.SelectTab(tpData);
        }

        /* Step 2: Setup Schema */
        private void step2DefineSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Build a blank schema from the data loaded
             */
            dgvSchema.Rows.Clear();
            foreach (DataColumn column in _dtData.Columns)
            {
                string name = column.ColumnName;
                dgvSchema.Rows.Add(name, "", "0", false);
            }
            dgvSchema.DefaultCellStyle.Font = new Font("Calibri", 12);
            tabControl1.SelectTab(tpSchema);
        }

        private void bSaveSchema_Click(object sender, EventArgs e)
        {
            /* Save the schema so it can be loaded again later
             */
            _dtSchema = DataHelper.ToDataTable(dgvSchema);

            FileHelper.ToCSV(_dtSchema, _schemaFile + ".schema");
        }


        private void bRestoreSchema_Click(object sender, EventArgs e)
        {
            fileLoadData = new OpenFileDialog();
            DialogResult dialog = fileLoadData.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                _schemaFile = fileLoadData.FileName;
                RestoreSchema();
            }
        }
        
        private void RestoreSchema()
        {
            if (!File.Exists(_schemaFile)) { return; }

            /* Take a saved schema and repopulate the UX
             */
            dgvSchema.Rows.Clear();
            if (_dtSchema != null) { _dtSchema.Rows.Clear(); }

            using (TextFieldParser parser = new TextFieldParser(_schemaFile))
            {
                dgvSchema.Rows.Clear();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // ignore header row
                string[] fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    //Processing row
                    fields = parser.ReadFields();
                    if (fields[0].Length > 0)
                    {
                        dgvSchema.Rows.Add(fields[0], fields[1], fields[2], fields[3]);
                    }
                }
            }
            dgvSchema.DefaultCellStyle.Font = new Font("Calibri", 12);
        }

        private void step3ViewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* This window works to either redact or mask data loaded in step one.
             */
            if (WindowMode == WindowModeAnonymization)
            {
                RedactDataAsync();
            }
            else
            {
                MaskDataAsync();
            }
            
        }
        private async void RedactDataAsync()
        {
            /* This method goes through several steps to redact the data according to the schema. 
             * 
             * It is important to realize these steps are how to use the PII Vault manually. At the time
             * this code was written a single endpoint to do this work had not yet been released.
             * 
             * This method shows how to use the GetPolyId endpoing in bulk mode manually
             */

            /* build results datatable with poly-id */
            int sourceColCnt = -1;
            int destColCnt = -1;
            string[] columnList = new string[dgvSchema.RowCount];
            bool[] includeList = new bool[dgvSchema.RowCount];
            string[] groupList = new string[dgvSchema.RowCount];

            _dtResult = new DataTable();
            DataColumn col = new DataColumn("PolyAnonymous-Id");
            _dtResult.Columns.Add(col);

            ProfileHelper profileHelper = new ProfileHelper();

            _piiCol = new List<PiiCol>();
            foreach (DataGridViewRow row in dgvSchema.Rows)
            {
                /* this method does not take into account the size of the input data set. 
                 * however, care should be taken not to send too much data to the vault in 
                 * any one call. */
                sourceColCnt++;
                if (row.Cells[0].Value == null) { break; }

                string name = row.Cells[0].Value.ToString();
                string piiType = row.Cells[1].Value.ToString();
                string colGroup = row.Cells[2].Value.ToString();
                string redactCol = row.Cells[3].Value.ToString();

                columnList[sourceColCnt] = name;
                includeList[sourceColCnt] = (redactCol.ToLower() == "false");

                /* determine how to handle each of the columns in the schema */
                if (redactCol.ToLower() == "false")
                {
                    col = new DataColumn(name);
                    _dtResult.Columns.Add(col);
                }
                if (piiType == "Unique Key to Individual") { _sourceIndex = name; };

                /* build list of columns to send to vault */
                if (piiType == "Non-PII Data Field" || piiType == "" || piiType == null)
                {
                    // intentionally empty
                }
                else
                {
                    _piiCol.Add(new PiiCol(name, piiType, colGroup));
                }
            }
            /* initial result data table with the correct number of rows */
            int rowCnt = _dtData.Rows.Count;
            for (int x = 0; x <= rowCnt; x++)
            {
                DataRow row = _dtResult.NewRow();
                _dtResult.Rows.Add(row);
            }

            rowCnt = _dtResult.Rows.Count;

            /* populate the resulting grid with data that is not being redacted */
            sourceColCnt = -1;
            destColCnt = 0;

            foreach (DataColumn dataCol in _dtData.Columns)
            {
                sourceColCnt++;

                if (includeList[sourceColCnt])
                {
                    destColCnt++;
                    rowCnt = -1;
                    foreach (DataRow row in _dtData.Rows)
                    {
                        rowCnt++;
                        _dtResult.Rows[rowCnt][destColCnt] = row[dataCol.ColumnName].ToString();
                    }
                }
            }

            /* add the unique identifer as the poly-id so we can identify and replace it later */
            rowCnt = -1;
            foreach (DataRow row in _dtData.Rows)
            {
                rowCnt++;
                _dtResult.Rows[rowCnt][_polyIndexName] = row[_sourceIndex].ToString();
            }

            /* get credentials to the PII Vault. Must have been setup already */
            DialogResult tokenResult = GetToken(true);
            if (tokenResult == DialogResult.Cancel)
            {
                return;
            }

            _httpService = new HttpService(_Token, _environment.BaseApiUrl);

            /* loop through data and send to Vault 
             * Ideally, you would want to chunk this data into multiple calls if there are a lot of rows 
             * You could also speed up the process by only sending each unique profile to the PII Vault once
             */
            ProfilesDTO profileRequest = new ProfilesDTO();
            rowCnt = -1;
            foreach (DataRow row in _dtData.Rows)
            {
                rowCnt++;
                ProfileRequestDTO profile = profileHelper.BuildProfile(row, _piiCol, rowCnt);

                profileRequest.Profiles.Add(profile);
            }


            /* add poly-id */
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string json = JsonConvert.SerializeObject(profileRequest);
            var response = await _httpService.PutAsync<List<ProfileResponseDTO>>("api/profiles/GetPolyIdBulk", profileRequest);

            sw.Stop();
            long elapsed = sw.ElapsedMilliseconds;

            if (response.Success)
            {
                foreach (ProfileResponseDTO profileResponse in response.Data)
                {
                    int row = profileResponse.Index;
                    string polyId = profileResponse.PolyId.ToString();
                    _dtResult.Rows[row][_polyIndexName] = polyId;
                }
            }


            // finish up
            dgvResult.DataSource = _dtResult;
            dgvResult.Refresh();
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.DefaultCellStyle.Font = new Font("Calibri", 12);
            tabControl1.SelectTab(tpResults);
        }
        private async void MaskDataAsync()
        {
            /* This method masks, rather than redacts, the marked PII fields.
             */
            /* build results datatable with poly-id */
            int sourceColCnt = -1;
            string[] columnList = new string[dgvSchema.RowCount];
            bool[] includeList = new bool[dgvSchema.RowCount];
            string[] groupList = new string[dgvSchema.RowCount];

            _dtResult = new DataTable();
            _dtResult = _dtData.Clone();
            foreach (DataColumn col in _dtResult.Columns)
            {
                col.ReadOnly = false;
                col.AllowDBNull = true;
                col.Unique = false;
            }

            ProfileHelper profileHelper = new ProfileHelper();

            _piiCol = new List<PiiCol>();
            foreach (DataGridViewRow schemaRow in dgvSchema.Rows)
            {
                /* This method will only send each unique profile to the PII Vault once. However,
                 * it does not take into account how many profiles are sent within that call.
                 * care should be taken not to send too much data to the vault in 
                 * any one call. */
                sourceColCnt++;
                if (schemaRow.Cells[0].Value == null) { break; }

                string name = schemaRow.Cells[0].Value.ToString();
                string piiType = schemaRow.Cells[1].Value.ToString();
                string colGroup = schemaRow.Cells[2].Value.ToString();
                string redactCol = schemaRow.Cells[3].Value.ToString();

                columnList[sourceColCnt] = name;
                includeList[sourceColCnt] = (redactCol.ToLower() == "false");

                if (piiType == "Unique Key to Individual") { _sourceIndex = name; };

                /* build list of columns to send to vault */
                if (piiType == "Non-PII Data Field" || piiType == "" || piiType == null)
                {
                    // intentionally empty
                }
                else
                {
                    _piiCol.Add(new PiiCol(name, piiType, colGroup));
                }
            }

            /* get a token to the vault */
            DialogResult tokenResult = GetToken(true);
            if (tokenResult == DialogResult.Cancel)
            {
                return;
            }

            _httpService = new HttpService(_Token, _environment.BaseApiUrl);

            /* loop through data and send to Vault in packets  of 1K */
            int rowCnt = -1;
            string priorSorceSystemKey = "";
            
            DataView dv = _dtData.DefaultView;
            dv.Sort = _sourceIndex + " asc";
            DataTable dtTemp = dv.ToTable();

            /* create the request class */
            ProfileRequestDTO profileRequest = new ProfileRequestDTO();
            ProfilesDTO profilesRequest = new ProfilesDTO();
            ApiResponse<PseudonymResponseDTO> profilesResponse = new ApiResponse<PseudonymResponseDTO>();

            /* add a column which will let us link data rows to profile responses */ 
            DataColumn indexCol = dtTemp.Columns.Add("Index", typeof(Int32));

            foreach (DataRow dataRow in dtTemp.Rows)
            {
                /* if we are getting a pseudonym for the same profile as the prior row, skip and just mask the row */
                if (dataRow[_sourceIndex].ToString() != priorSorceSystemKey)
                {
                    rowCnt++;
                    priorSorceSystemKey = dataRow[_sourceIndex].ToString();
                    profileRequest = profileHelper.BuildProfile(dataRow, _piiCol, rowCnt);
                    profileRequest.Index = rowCnt;
                    profilesRequest.Profiles.Add(profileRequest);
                }
                dataRow["Index"] = rowCnt;
            }

            /*     */
            string json = JsonConvert.SerializeObject(profilesRequest);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            /* send all unqiue profiles to the PII Vault */
            profilesResponse = await _httpService.PutAsync<PseudonymResponseDTO>("api/profiles/GetPolyIdWithPseudonymBulk", profilesRequest);

            sw.Stop();
            long elapsed = sw.ElapsedMilliseconds;

            if (profilesResponse.Success)
            {
                /* now go through every data row and find the appropriate response class for that row uning the Index value*/
                foreach( DataRow row in dtTemp.Rows)
                {
                    string tempIndex = row["Index"].ToString();
                    ProfileResponseDTO profile = profilesResponse.Data.Profiles.First(x => x.Index == Int16.Parse(row["Index"].ToString()));
                    DataRow newRow = profileHelper.MaskRowPii(profile, _piiCol, row);
                    _dtResult.ImportRow(newRow);
                }
            }

            // finish up
            dgvResult.DataSource = _dtResult;
            dgvResult.Refresh();
            dgvResult.DefaultCellStyle.Font = new Font("Calibri", 12);
            tabControl1.SelectTab(tpResults);
        }
        private void SelectNewEnvironment(IEnvironment env)
        {
            /* it is simply easier to have all of the settings for connecting to the PII Vault saved so they
             * do not have to be typed in each time.
             */

            _environment = env;

            if (env != null)
            {
                _frmLogin.Environment = env;
                this.Text += $" - {env.Nickname}";
            }
            else
            {
                this.Text += $" - No Environment Set";
            }
        }
        public void SetMode(string newMode)
        {
            /* Set the window mode: Redact or Mask
             */

            this.WindowMode = newMode;

            SetTitle();
        }

        private void SetTitle()
        {
            if (WindowMode == WindowModeMasking)
            {
                this.Text = $"PII Vault Data Masking";
            }
            else
            {
                this.Text = $"PII Vault Pass Through Anonymizaion";
            }

            if (_environment == null)
            {
                this.Text += $" - No Environment Set";
            }
            else
            {
                this.Text += $" - {_environment.Nickname}";
            }
        }
        private void ReloadComboBoxOptions(IEnumerable<IEnvironment> environments)
        {
            /* load the environments combobox
             */

            cboEnvironments.Items.Clear();

            _environments = environments;

            foreach (IEnvironment env in environments)
            {
                cboEnvironments.Items.Add(env);

                if (env.Default)
                {
                    cboEnvironments.SelectedIndex = cboEnvironments.Items.Count - 1;

                    SelectNewEnvironment(env);
                }
            }
        }

        private void CboEnvironments_SelectedValueChanged(object sender, EventArgs e)
        {
            IEnvironment selected = (IEnvironment)cboEnvironments.SelectedItem;

            SelectNewEnvironment(selected);
        }

        private DialogResult GetToken(bool alwaysAsk)
        {
            /* Before using the PII Vault, you must obtain a security token
             */
             
            DialogResult rtnVal = TokenHelper.GetToken(alwaysAsk, _frmLogin, out _Token);

            return rtnVal;
        }

        private void bNewEnvironment_Click(object sender, EventArgs e)
        {
            /* Open dialog to define a new environment. This dialog allows for two sets of credentials
             * because two are needed to do anonymous data matching
             */

            using (frmNewEnvironment newEnv = new frmNewEnvironment())
            {
                newEnv.ShowDialog();

                if (newEnv.Environment != null)
                {
                    // If we selected this to be true
                    if (newEnv.Environment.Default)
                    {
                        foreach (IEnvironment env in _environments) env.Default = false;
                    }

                    // Add new environment to list and re-write file
                    List<IEnvironment> newEnvs = _environments.ToList();
                    newEnvs.Add(newEnv.Environment);
                    EnvironmentFlatFileHandler.AddNewEnvironment(newEnvs);
                    ReloadComboBoxOptions(newEnvs);
                }
            }
        }

        private void bEditEnvironment_Click(object sender, EventArgs e)
        {
            int index = cboEnvironments.SelectedIndex;

            if (_environment != null)
            {
                using (frmNewEnvironment newEnv = new frmNewEnvironment(_environment))
                {
                    newEnv.ShowDialog();

                    if (newEnv.Environment != null)
                    {
                        List<IEnvironment> envs = new List<IEnvironment>();

                        // If we selected this to be true
                        if (newEnv.Environment.Default)
                        {
                            foreach (IEnvironment env in _environments) env.Default = false;
                        }

                        for (int i = 0; i < _environments.Count(); i++)
                        {
                            if (i == index)
                            {
                                envs.Add(newEnv.Environment);
                            }
                            else
                            {
                                envs.Add(_environments.ElementAt(i));
                            }
                        }

                        EnvironmentFlatFileHandler.AddNewEnvironment(envs);
                        ReloadComboBoxOptions(envs);
                    }
                }
            }
        }

        private void bLoadEnvironment_Click(object sender, EventArgs e)
        {
            fileLoadData = new OpenFileDialog();
            DialogResult dialog = fileLoadData.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                IEnumerable<IEnvironment> environments = EnvironmentFlatFileHandler.GetEnvironments(fileLoadData.FileName); // Read file
                EnvironmentFlatFileHandler.AddNewEnvironment(environments); // Overwrite existing file (if it exists)
                ReloadComboBoxOptions(environments); // Reload the combo box
            }
        }

        private void bPurgeProfiles_Click(object sender, EventArgs e)
        {

            PurgeProfiles();
        }

        private async void PurgeProfiles()
        {
            /* Purge all of the profiles in the PII Vault for the selected Account
             */
            string token = null;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to completely remove all profiles? This action cannot be undone", "Please Confirm", buttons);
            if (result == DialogResult.Yes)
            {
                DialogResult tokenResult = TokenHelper.GetToken(true, _frmLogin, out token);
                if (tokenResult == DialogResult.OK)
                {
                    _Token = token;
                    buttons = MessageBoxButtons.OK;
                    ProfileRequestDTO requestDTO = new ProfileRequestDTO();
                    _httpService = new HttpService(_Token, _environment.BaseApiUrl);

                    var response = await _httpService.PutAsync<bool>("api/profiles/PurgeAccountProfiles", requestDTO);
                    if (response.Success)
                    {
                        result = MessageBox.Show("Profiles for selected account purged", "Purge Complete", buttons);
                    }
                    else
                    {
                        result = MessageBox.Show("Profiles for selected account COULD NOT BE purged. " + response.Error, "Purge Failed", buttons);
                    }
                }
            }
            else
            {
                result = MessageBox.Show("Profiles for selected account NOT purged. ", "Purge Cancelled", buttons);
            }
        }

        private void bPopulatePolyIds_Click(object sender, EventArgs e)
        {
            PopulatePolyIds();
        }

        private void PopulatePolyIds()
        {
            /* put the poly-anonymous IDs from the PII Vault onto the appropriate data records 
             */

            dgvPolyIds.Rows.Clear();
            foreach (DataRow row in _dtResult.Rows)
            {
                string polyId = row[0].ToString();
                dgvPolyIds.Rows.Add(polyId);
            }
        }

        private void bReidentify_Click(object sender, EventArgs e)
        {
            Reidentify();
        }
        private async void Reidentify()
        {
            /* this method shows how to use the GetProfile endpoint to obtain the PII for a profile.
             * Note: Not every instance of the PII Vault will have this endoint
             */

            string token = null;
            DialogResult tokenResult = TokenHelper.GetToken(true, _frmLogin, out token);
            if (tokenResult != DialogResult.OK) { return; }

            _Token = token;
            _httpService = new HttpService(_Token, _environment.BaseApiUrl);

            _dtPolyIds = DataHelper.ToDataTable(dgvPolyIds);

            foreach( DataGridViewRow row in dgvPolyIds.Rows)
            {
                string FirstName = "", LastName= "", Gender="", Street="", City="", State="", Zip="", Phone="", Email="";

                PolyIdRequestDTO requestDTO = new PolyIdRequestDTO();
                string test = row.Cells[0].Value.ToString();
                if (test.Length < 32) { break; }

                requestDTO.PolyId = Guid.Parse(row.Cells[0].Value.ToString());
                var response = await _httpService.PostAsync<ProfileResponseDTO>("api/profiles/GetProfile", requestDTO);

                if (response.Success)
                {
                    FirstName = DataHelper.IsNull(response.Data.FirstName);
                    if (response.Data.Addresses.Length > 0) 
                    {
                        Street = response.Data.Addresses[0].StreetAddress1;
                        City = response.Data.Addresses[0].City;
                        State = response.Data.Addresses[0].StateCode;
                        Zip = City = response.Data.Addresses[0].PostalCode;
                    }
                    if (response.Data.Phones.Length > 0)
                    {
                        Phone = City = response.Data.Phones[0].PhoneNumber;
                    }
                    if (response.Data.Emails.Length > 0)
                    {
                        Email = response.Data.Emails[0].EmailAddress;
                    }

                    dgvReidentified.Rows.Add( response.Data.FirstName,
                                              response.Data.LastName,
                                              response.Data.Gender,
                                              Street,
                                              City,
                                              State,
                                              Zip,
                                              Phone,
                                              Email);
                }
            }
        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save CSV File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                FileHelper.ToCSV(_dtResult, saveFileDialog1.FileName);
            }
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* allow user to load data from CSV or database */
            _sourceType = cbSource.Text;
            if (cbSource.Text == "CSV")
            {
                ShowSourceControls(false);
            }
            else
            {
                ShowSourceControls(true);
                string filename = Properties.Settings.Default["SourceFilename"].ToString();
                if (filename != null)
                {
                    LoadSettings(filename);
                }   
            }

            Properties.Settings.Default["SourceType"] = cbSource.Text;
            Properties.Settings.Default.Save();
        }

        private void ShowSourceControls(bool showControls)
        {
            /* either show or hide database connection parameters */
            foreach (Control con in _sourceControls)
            {
                con.Visible = showControls;
            }
        }

        private void bSourceOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileLoadSettings = new OpenFileDialog();
            DialogResult dialog = fileLoadSettings.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                LoadSettings(fileLoadSettings.FileName);
            }
        }

        private void bSourceSave_Click(object sender, EventArgs e)
        {
            /* save the database connection settings. if using this in production please use appropriate security on 
             * accounts and passwords */
            SaveFileDialog fileDialog = new SaveFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                DataColumn col = new DataColumn("setting");
                dt.Columns.Add(col);
                dt.Rows.Add(tbSourceSource.Text);
                dt.Rows.Add(tbSourceDatabase.Text);
                dt.Rows.Add(tbSourceUser.Text);
                dt.Rows.Add(Encrypt.EncryptString(tbSourcePassword.Text, "weakpassword"));
                string sqlText = tbSourceSQL.Text;
                sqlText = sqlText.Replace("\r", "^^^");
                sqlText = sqlText.Replace("\n", "&&&");
                dt.Rows.Add(sqlText);

                FileHelper.ToCSV(dt, fileDialog.FileName);

                Properties.Settings.Default["SourceFilename"] = fileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
        private void LoadSettings(string filename)
        {
            /* restore previously saved settings */
            if ( string.IsNullOrEmpty(filename)) { return; }

            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // ignore header row
                string[] fields = parser.ReadFields();
                fields = parser.ReadFields();
                tbSourceSource.Text = fields[0];

                fields = parser.ReadFields();
                tbSourceDatabase.Text = fields[0];

                fields = parser.ReadFields();
                tbSourceUser.Text = fields[0];

                fields = parser.ReadFields();
                tbSourcePassword.Text = Encrypt.DecryptString(fields[0], "weakpassword");

                fields = parser.ReadFields();
                string sqlText = fields[0].Replace("^^^", "\r");
                sqlText = sqlText.Replace("&&&", "\n");

                tbSourceSQL.Text = sqlText;
            }
        }
        
    }
}
