using System;

namespace PIIVaultDemoApp.Environments
{
    public interface IEnvironment
    {
        string Nickname { get; set; }
        Guid AccountId1 { get; set; }
        string ApiKey1 { get; set; }
        Guid AccountId2 { get; set; }
        string ApiKey2 { get; set; }
        string BaseApiUrl { get; set; }
        bool Default { get; set; }
    }
}
