using PIIVault.Shared.Models;
using PIIVaultDemoApp.Environments;
using PIIVaultDemoApp.Helpers;
using System;
using System.Windows.Forms;



namespace PIIVaultDemoApp
{
    public partial class frmLogin : Form
    {
        private IEnvironment _environment;
        
        public string Token { get; set; }
        public IEnvironment Environment
        {
            get { return _environment; }
            set
            {
                _environment = value;

                if (_environment != null)
                {
                    txtAccountId.Text = _environment.AccountId1.ToString();
                    txtApiKey.Text = _environment.ApiKey1;
                    txtAccountId2.Text = _environment.AccountId2.ToString();
                    txtApiKey2.Text = _environment.ApiKey2;
                }
            }
        }

        public frmLogin(IEnvironment env = null)
        {
            InitializeComponent();

            if (env != null) { _environment = env; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginApi(btnLogin, txtAccountId.Text, txtApiKey.Text);
        }
        private async void LoginApi( Button button, string accountId, string key)
        {
            PiiVaultEnvironment piiVaultEnvironment = new PiiVaultEnvironment();
            piiVaultEnvironment.AccountId = Guid.Parse(accountId);
            piiVaultEnvironment.ApiKey = key;
            piiVaultEnvironment.BaseApiUrl = _environment.BaseApiUrl;

            var httpService = new HttpService(_environment.BaseApiUrl);

            var response = await httpService.PostAsync<TokenModel>("api/auth/login", piiVaultEnvironment);

            if (response.Success)
            {
                Token = response.Data.Token;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Token = null;
                MessageBox.Show(response.Error.Message);
            }
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            LoginApi(btnLogin2, txtAccountId2.Text, txtApiKey2.Text);
        }
    }
}
