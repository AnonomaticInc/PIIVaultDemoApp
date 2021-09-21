using Guid = System.Guid;
using System.Windows.Forms;
using PIIVaultDemoApp.Environments;

namespace PIIVaultDemoApp
{
    public partial class frmNewEnvironment : Form
    {
        public IEnvironment Environment { get; private set; }

        public frmNewEnvironment() { InitializeComponent(); }

        public frmNewEnvironment(IEnvironment env)
        {
            InitializeComponent();

            txtNickname.Text = env.Nickname;
            txtAccountId1.Text = env.AccountId1.ToString();
            txtApiKey1.Text = env.ApiKey1;
            txtAccountId2.Text = env.AccountId2.ToString();
            txtApiKey2.Text = env.ApiKey2;
            txtBaseUri.Text = env.BaseApiUrl;
            chkDefault.Checked = env.Default;

            Text = $"Editing {env.Nickname}";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            bool guid1Trial = Guid.TryParse(txtAccountId1.Text.Trim(), out Guid account1);
            bool guid2Trial = Guid.TryParse(txtAccountId2.Text.Trim(), out Guid account2);

            if (txtNickname.Text.Trim().Length == 0 ||
                txtAccountId1.Text.Trim().Length == 0 ||
                txtApiKey1.Text.Trim().Length == 0 
                || txtAccountId2.Text.Trim().Length == 0 ||
                txtApiKey2.Text.Trim().Length == 0 ||
                txtBaseUri.Text.Trim().Length == 0
                )
            {
                MessageBox.Show("At least the first account information and profile name must be supplied", "Form incomplete", MessageBoxButtons.OK);
            }
            else if (!guid1Trial )
            {
                MessageBox.Show("Account IDs must be a valid GUID", "Valid GUID", MessageBoxButtons.OK);
            }
            else
            {
                // Add new environment
                Environment = new EnvironmentFlatFile
                {
                    Nickname = txtNickname.Text.Trim(),
                    AccountId1 = account1,
                    ApiKey1 = txtApiKey1.Text.Trim(),
                    AccountId2 = account2,
                    ApiKey2 = txtApiKey2.Text.Trim(),
                    BaseApiUrl = txtBaseUri.Text.Trim(),
                    Default = chkDefault.Checked
                };

                Close();
            }
        }
    }
}
