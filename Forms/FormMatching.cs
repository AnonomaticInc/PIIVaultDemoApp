using Newtonsoft.Json;
using PIIVault.Shared.Models;
using PIIVaultDemoApp.Environments;
using PIIVaultDemoApp.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PIIVaultDemoApp.Forms
{
    public partial class FormMatching : Form
    {
        string _MatchTestFile = null;
        DataTable _dtMatchTests = new DataTable();
        DataTable _dtTestList = new DataTable();
        DataTable _dtTestResults = new DataTable();
        private OpenFileDialog fileLoadData;
        private string _Token;
        private IEnvironment _environment;
        private readonly frmLogin _frmLogin;
        private IEnumerable<IEnvironment> _environments;
        private HttpService _httpService;
        private bool _testExpressionChanged = false;
        private int _currentTestRow = 0;

        public FormMatching()
        {
            InitializeComponent();
            RestoreSettings();
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            _environments = EnvironmentFlatFileHandler.GetEnvironments();
            _frmLogin = new frmLogin();

            foreach (IEnvironment env in _environments)
            {
                if (env.Default)
                {
                    _frmLogin.Environment = env;
                    _environment = env;
                    this.Text += $" - {env.Nickname}";
                }
            }
        }

        private void RestoreSettings()
        {
            string matchFile = Properties.Settings.Default.Properties["MatchFile"].DefaultValue.ToString();
            if (matchFile != null)
            {
                tbMatchTests.Text = matchFile;
                _MatchTestFile = matchFile;
            }
        }

        private void bTestLoad_Click(object sender, EventArgs e)
        {
            LoadTests();
        }

        private void LoadTests()
        {
            if (!GetMatchFile()) { return; }

            _dtMatchTests.Reset();
            _dtMatchTests = ReadCSV.GetDataTable(_MatchTestFile);
            dgvTests.DataSource = _dtMatchTests;
            dgvTests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void bMatchTests_Click(object sender, EventArgs e)
        {
            GetMatchFile();
        }

        private bool GetMatchFile()
        {
            fileLoadData = new OpenFileDialog();
            DialogResult dialog = fileLoadData.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                _dtMatchTests.Rows.Clear();
                _dtMatchTests = ReadCSV.GetDataTable(fileLoadData.FileName);
                _MatchTestFile = fileLoadData.FileName;
                tbMatchTests.Text = _MatchTestFile;
                Properties.Settings.Default.Properties["MatchFile"].DefaultValue = _MatchTestFile;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {

            }
            ;
        }

        private void BuildTestList()
        {
            if (dgvTestsToRun.Rows.Count > 0) { dgvTestsToRun.Rows.Clear(); }

            _dtTestList = DataHelper.ToDataTable(dgvTests);

            foreach (DataRow row in _dtTestList.Rows)
            {
                if (row[0].ToString().Length > 0)
                {
                    int newRow = dgvTestsToRun.Rows.Add(new DataGridViewRow());
                    dgvTestsToRun.Rows[newRow].Cells["RunTest"].Value = true;
                    dgvTestsToRun.Rows[newRow].Cells["TestName"].Value = row[0].ToString();
                }
            }
        }

        private void bBuildList_Click(object sender, EventArgs e)
        {
            BuildTestList();
        }

        private void bRunTests_Click(object sender, EventArgs e)
        {
            RunTests();
        }
        private async void RunTests()
        {
            string testExpression = "";
            MatchRequestDTO requestDTO = new MatchRequestDTO();
            DataTable dtTestsToRun = DataHelper.ToDataTable(dgvTestsToRun);
            foreach ( DataRow row in dtTestsToRun.Rows)
            {
                if (row["RunTest"].ToString().ToLower() == "true")
                {
                    string testToRun = row["TestName"].ToString();

                    testExpression = null;
                    foreach (DataRow testRow in _dtTestList.Rows)
                    {
                        if (testRow[0] == row["TestName"])
                        {
                            testExpression = testRow[1].ToString();
                            break;
                        }
                    }

                    if (testExpression != null)
                    {
                        MatchProcDTO matchProc = new MatchProcDTO();
                        matchProc.Name = row["TestName"].ToString();
                        matchProc.Expr = testExpression;
                        requestDTO.MatchProcs.Add(matchProc);
                    }
                }
            }

            if (requestDTO.MatchProcs.Count == 0) { return; }

            DialogResult tokenResult = GetToken(true);
            if (tokenResult == DialogResult.Cancel)
            {
                return;
            }

            _httpService = new HttpService(_Token, _environment.BaseApiUrl);

            string json = JsonConvert.SerializeObject(requestDTO);

            var response = await _httpService.PostAsync<List<MatchResponseDTO>>("api/match", requestDTO);
            if (response.Success)
            {
                //MessageBox.Show("Match request successful", "Matching Success", MessageBoxButtons.OK);
                ShowMatchResults();
            }
            else
            {
                MessageBox.Show($"Match request was unsuccessful. {response.Error.Message}", "Matching Failed", MessageBoxButtons.OK);
            }

        }

        private async void ShowMatchResults()
        {
            _dtTestResults.Rows.Clear();
            MatchRequestDTO matchRequestDTO = new MatchRequestDTO();

            var response = await _httpService.GetAsync<List<MatchResponseDTO>>("api/match");
            if (response.Success)
            {
                _dtTestResults = DataHelper.ToDataTable(response.Data);
                dgvTestResults.DataSource = _dtTestResults;
            }
            labelMatchCount.Text = $"{_dtTestResults.Rows.Count.ToString()} Matches";
        }

            private DialogResult GetToken(bool alwaysAsk)
        {
            DialogResult rtnVal = TokenHelper.GetToken(alwaysAsk, _frmLogin, out _Token);

            return rtnVal;
        }

        private void dgvTests_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTest(e.RowIndex);
        }

        private void UpdateTest(int row)
        {
            try
            {
                if (_testExpressionChanged)
                {
                    string newTest = tbTestExpression.Text;
                    string oldTest = _dtMatchTests.Rows[_currentTestRow]["MatchExpression"].ToString();
                    if (newTest != oldTest)
                    {
                        _dtMatchTests.Rows[_currentTestRow]["MatchExpression"] = newTest;
                    }
                }
                _currentTestRow = row;
                tbTestExpression.Text = _dtMatchTests.Rows[row]["MatchExpression"].ToString();
                _testExpressionChanged = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void tbTestExpression_TextChanged(object sender, EventArgs e)
        {
            _testExpressionChanged = true;
        }

        private void bTestSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save CSV File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                FileHelper.ToCSV(_dtMatchTests, saveFileDialog1.FileName);
                _MatchTestFile = saveFileDialog1.FileName;
            }
        }

        private void bSaveMatchResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save CSV File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                FileHelper.ToCSV(_dtTestResults, saveFileDialog1.FileName);
            }
        }
    }
}
