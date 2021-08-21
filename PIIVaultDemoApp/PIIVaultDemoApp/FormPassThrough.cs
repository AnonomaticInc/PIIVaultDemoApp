using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PIIVault.Shared.Models;
using PIIVaultDemoApp.Helpers;
using Newtonsoft.Json;
using PIIVaultDemoApp.Environments;
using System.Linq;

namespace PIIVaultDemoApp
{
    public partial class FormPassThrough : Form
    {
        private OpenFileDialog fileLoadData;
        private string _dataFile;
        private string _schemaFile;
        private DataTable _dtSchema;
        private DataTable _dtData;
        private DataTable _dtResult;
        private string _polyIdColName = "PolyAnonymous-Id";
        private string _sourceIdCol = "";
        private List<PiiCol> _piiCol = new List<PiiCol>();
        private HttpService _httpService;
        private IEnvironment _environment;
        private readonly frmLogin _frmLogin;
        private IEnumerable<IEnvironment> _environments;

        public FormPassThrough()
        {
            InitializeComponent();
            _frmLogin = new frmLogin();

            _environments = EnvironmentFlatFileHandler.GetEnvironments();

            ReloadComboBoxOptions(_environments);
            cboEnvironments.SelectedValueChanged += CboEnvironments_SelectedValueChanged;
        }

        private void step1LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            fileLoadData = new OpenFileDialog();
            DialogResult dialog = fileLoadData.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                LoadSourceData();
            }
        }

        private void LoadSourceData()
        {
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
                //AddLog($"Error: {ex.Message}");
            }
            //SetGridViewRowCount();
            tabControl1.SelectTab(tpData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* Step 2: Setup Schema */
        private void step2DefineSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            //DataTable dtSchema = (DataTable)dgvSchema.DataSource;
            _dtSchema = ToDataTable(dgvSchema);

            FileHelper.ToCSV(_dtSchema, _schemaFile);
        }


        private void bRestoreSchema_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            fileLoadData = new OpenFileDialog();
            DialogResult dialog = fileLoadData.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                _schemaFile = fileLoadData.FileName;
                RestoreSchema();
            }
        }
        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add(dataGridViewColumn.Name);
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
        private void RestoreSchema()
        {
            dgvSchema.Rows.Clear();
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

        private async void step3ViewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

                if (redactCol.ToLower() == "false")
                {
                    col = new DataColumn(name);
                    _dtResult.Columns.Add(col);
                }
                if (piiType == "Unique Key to Individual") { _sourceIdCol = name; };

                /* build list of columns to send to vault */
                if (piiType == "Non-PII Data Field" || piiType == "" || piiType == null)
                {

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
                _dtResult.Rows[rowCnt][_polyIdColName] = row[_sourceIdCol].ToString();
            }

            DialogResult tokenResult = GetToken(true);
            if (tokenResult == DialogResult.Cancel)
            {
                return;
            }

            _httpService = new HttpService(_frmLogin.Token, _environment.BaseApiUrl);

            /* loop through data and send to Vault in packets  of 1K */
            ProfilesDTO profileRequest = new ProfilesDTO();
            rowCnt = -1;
            foreach (DataRow row in _dtData.Rows)
            {
                rowCnt++;
                ProfileRequestDTO profile = profileHelper.BuildProfile(row, _piiCol, rowCnt);

                profileRequest.Profiles.Add(profile);
            }


            /* add poly-id */            
            string json = JsonConvert.SerializeObject(profileRequest);
            var response = await _httpService.PutAsync<List<ProfileResponseDTO>>("api/profiles/GetPolyIdBulk", profileRequest);
            if (response.Success)
            {
                foreach (ProfileResponseDTO profileResponse in response.Data)
                {
                    int row = profileResponse.Index;
                    string polyId = profileResponse.PolyId.ToString();
                    _dtResult.Rows[row][0] = polyId;
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
            _environment = env;

            if (env != null)
            {
                _frmLogin.Environment = env;
                Text = $"PIIVault.Client - {env.Nickname}";
            }
        }
        private void ReloadComboBoxOptions(IEnumerable<IEnvironment> environments)
        {
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
            DialogResult rtnVal = DialogResult.OK;

            if (_frmLogin.Token == null || alwaysAsk)
            {
                rtnVal = _frmLogin.ShowDialog(this);
            }

            return rtnVal;
        }

        private void bNewEnvironment_Click(object sender, EventArgs e)
        {
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
    }

}
