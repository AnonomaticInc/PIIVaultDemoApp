using Guid = System.Guid;

namespace PIIVaultDemoApp.Environments
{
    public class EnvironmentFlatFile : IEnvironment
    {
        #region Constructor(s)
        public EnvironmentFlatFile() { }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return Nickname;
        }
        #endregion

        #region Interface Members
        public string Nickname { get; set; }
        public Guid AccountId1 { get; set; }
        public string ApiKey1 { get; set; }
        public Guid AccountId2 { get; set; }
        public string ApiKey2 { get; set; }
        public string BaseApiUrl { get; set; }
        public bool Default { get; set; }
        #endregion
    }
}
