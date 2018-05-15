using System.Linq;
using System.Text.RegularExpressions;

namespace App4_5
{
    class GameBoardFactory
    {
        public GameBoard Create()
        {
            var width = 5;
            var height = 5;
            IConfigFile configFile = new ConfigFile();

            var configString = configFile.GetData(@"C:\Users\Luke\Documents\C#\Nowy folder\CSharpPractise\App4_5\gameconfiguration.cfg");

            if (configString != null)
            {
                var numberStrings = Regex.Split(configString, @"\D+");
                var numbers = numberStrings.Select(int.Parse).ToArray();
                width = numbers[0];
                height = numbers[1];
            }
            
            return new GameBoard(width, height);
        }
    }
}