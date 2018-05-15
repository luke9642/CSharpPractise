using System;
using System.IO;

namespace App4_5
{
    public class ConfigFile : IConfigFile
    {
        public string GetData(string filePath)
        {
            string configString; 
            
            if (File.Exists(filePath))
            {
                configString = File.ReadAllText(filePath);
            }
            else
            {
                throw new InvalidOperationException("Error while reading config");
            }

            return configString;
        }
    }
}