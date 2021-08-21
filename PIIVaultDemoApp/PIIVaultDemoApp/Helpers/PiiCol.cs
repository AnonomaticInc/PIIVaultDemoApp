namespace PIIVaultDemoApp.Helpers
{
    public class PiiCol
    {
        public PiiCol(string colName, string colType, string colGroup)
        {
            ColName = colName;
            PiiType = colType;
            ColGroup = colGroup;
        }
        public string ColName { get; set; }
        public string PiiType { get; set; }
        public string ColGroup { get; set; }

    }
}
