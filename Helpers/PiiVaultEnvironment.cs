using System;

namespace PIIVaultDemoApp.Helpers
{
    public class PiiVaultEnvironment
    {
        public Guid AccountId { get; set; }
        public string ApiKey { get; set; }
        public string BaseApiUrl { get; set; }
        public bool Default { get; set; }
    }
}
