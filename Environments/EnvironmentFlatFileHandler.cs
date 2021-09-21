using System;
using System.Collections.Generic;
using System.IO;

namespace PIIVaultDemoApp.Environments
{
    public static class EnvironmentFlatFileHandler
    {
        #region Private Members
        private static string _environmentFile = "environments.csv";
        private static int _nickname = 0;
        private static int _accountId1 = 1;
        private static int _apiKey1 = 2;
        private static int _accountId2 = 3;
        private static int _apiKey2 = 4;
        private static int _baseApiUrl = 5;
        private static int _default = 6;
        #endregion

        public static IEnumerable<IEnvironment> GetEnvironments(string filePath = null)
        {
            CheckIfFileExistsAndCreateIfItDoesnt();

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = _environmentFile;
            }

            List<IEnvironment> rtnVal = new List<IEnvironment>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] parts = line.Split(',');

                    // We're only expecting 5 items per line
                    // TO DO: maybe throw an exception if this is false
                    if (parts.Length == 7)
                    {
                        EnvironmentFlatFile newFile = new EnvironmentFlatFile
                        {
                            Nickname = parts[_nickname],
                            AccountId1 = Guid.Parse(parts[_accountId1]),
                            ApiKey1 = parts[_apiKey1],
                            AccountId2 = Guid.Parse(parts[_accountId2]),
                            ApiKey2 = parts[_apiKey2],
                            BaseApiUrl = parts[_baseApiUrl],
                            Default = (parts[_default] == "1")
                        };

                        rtnVal.Add(newFile);
                    }
                }
            }

            return rtnVal;
        }

        public static void AddNewEnvironment(IEnvironment env)
        {
            CheckIfFileExistsAndCreateIfItDoesnt();

            using (StreamWriter writer = new StreamWriter(_environmentFile, true))
            {
                if (env.Default) writer.WriteLine($"{env.Nickname},{env.AccountId1},{env.ApiKey1},{env.AccountId2},{env.ApiKey2},{env.BaseApiUrl},1");
                else writer.WriteLine($"{env.Nickname},{env.AccountId1},{env.ApiKey1},{env.AccountId2},{env.ApiKey2},{env.BaseApiUrl},0");
            }
        }

        public static void AddNewEnvironment(IEnumerable<IEnvironment> envs)
        {
            CheckIfFileExistsAndCreateIfItDoesnt();

            using (StreamWriter writer = new StreamWriter(_environmentFile, false))
            {
                foreach (IEnvironment env in envs)
                {
                    if (env.Default) writer.WriteLine($"{env.Nickname},{env.AccountId1},{env.ApiKey1},{env.AccountId2},{env.ApiKey2},{env.BaseApiUrl},1");
                    else writer.WriteLine($"{env.Nickname},{env.AccountId1},{env.ApiKey1},{env.AccountId2},{env.ApiKey2},{env.BaseApiUrl},0");
                }
            }
        }

        private static void CheckIfFileExistsAndCreateIfItDoesnt()
        {
            if (!File.Exists(_environmentFile))
            {
                using (StreamWriter creator = File.CreateText(_environmentFile))
                {
                }
            }
        }
    }
}
