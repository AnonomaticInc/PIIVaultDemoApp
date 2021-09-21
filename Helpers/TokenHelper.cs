using System.Windows.Forms;

namespace PIIVaultDemoApp.Helpers
{
    static class TokenHelper
    {
        /* Gets the credentials to be used to obtain a token from the PII Vault
         */

        public static DialogResult GetToken(bool alwaysAsk, frmLogin frmLogin, out string Token)
        {
            DialogResult rtnVal = DialogResult.OK;

            if (frmLogin.Token == null || alwaysAsk)
            {
                rtnVal = frmLogin.ShowDialog();
            }

            Token = frmLogin.Token;

            return rtnVal;
        }
    }
}
