namespace PIIVaultDemoApp.Helpers
{
    public class SQLHelper
    {
        public static string GetSelectTableName(string selectStatement)
        {
            string tableName = "";
            selectStatement = selectStatement.Replace("\r\n", " ");
            selectStatement = selectStatement.Replace("\r", " ");
            selectStatement = selectStatement.Replace("\n", " ");
            string[] components = selectStatement.Split(' ');
            int index = -1;
            foreach(string component in components)
            {
                index++;
                if (component.Trim().ToLower() == "from")
                {
                    if (components.Length >= index)
                    {
                        tableName = components[index + 1];
                        return tableName;
                    }
                }
            }
            return tableName;
        }
    }
}
