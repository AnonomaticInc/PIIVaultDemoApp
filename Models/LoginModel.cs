using System;

namespace PIIVaultDemoApp.Models
{
    public class LoginModel
    {
        /* Model used to log into the PII Vault and obtain a security token
         * The SunderId is a guid you can use to further encrypt your data within the PII Vault
         * Any data sent to the PII Vault with a specified Sunder Id will be completely unaccessible 
         * unless that same sunder id is provided for future calls
         */

        public Guid AccountId { get; set; }
        public string ApiKey { get; set; }
        public Guid? SunderId { get; set; }
    }
}
