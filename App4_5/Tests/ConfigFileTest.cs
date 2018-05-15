using System;
using NUnit.Framework;

namespace App4_5
{
    [TestFixture]
    public class ConfigFileTest
    {
        [TestCase(@"..\..\gameconfiguration.cfg")]
        [TestCase(@"..\gameconfiguration.cfg")]
        [TestCase(@"..\..\gamecoanfiguration.cfg")]
        public void CheckIncorrectFile(string fileName)
        {
            IConfigFile configFile = new ConfigFile();

            Assert.Throws<InvalidOperationException>(() => configFile.GetData(fileName));
        }
        
        [TestCase(@"C:\Users\Luke\Documents\C#\Nowy folder\CSharpPractise\App4_5\gameconfiguration.cfg")]
        public void CheckCorrectFile(string fileName)
        {
            IConfigFile configFile = new ConfigFile();
            Console.WriteLine(fileName);
            var data = configFile.GetData(fileName);

            Assert.AreEqual(data, "5 5");
        }
    }
}
