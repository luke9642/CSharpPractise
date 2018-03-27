using System;
using System.Collections.Generic;
using System.Linq;

namespace App1_1
{
    internal static class Program
    {
        public static void Main()
        {
            #region Intro

            Console.WriteLine("Witaj w grze Diablo");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[X] Zamknij program");

            var data = ReadProperValue(new List<string> {"1", "x"});
            
            ExitIfX(data);

            #endregion

            #region CreateHero

            var hero = CreateHero();

            Console.Clear();
            Console.WriteLine(hero.HeroClass + " " + hero.HeroName + " wyrusza na przygodę...");
            Console.WriteLine("Naciśnij dowolny przycisk...");
            Console.ReadKey();

            #endregion

            #region StartGame

            var locations = new List<Location>
            {
                Factory.CreateLocationWithTwoNpcs(),
                Factory.CreateEmptyLocation("Silverymoon", true),
                Factory.CreateEmptyLocation("Calimport", true),
                Factory.CreateEmptyLocation("Loc 4", false),
                Factory.CreateEmptyLocation("Loc 5", true),
                Factory.CreateEmptyLocation("Loc 6", false)
            };

            var currentLocation = locations[0];

            while (true)
            {
                ShowLocation(currentLocation);
                var list = GetRangeList(currentLocation.NonPlayerCharacters?.Length ?? 0);
                list.Add("T");
                list.Add("X");
                data = ReadProperValue(list);
                ExitIfX(data);
                
                if (data == "T")
                {
                    var filteredLocations = locations.Where(location => location.IsUnlocked && location != currentLocation).OrderBy(elem => elem.Name).ToList();
                    ShowLocations(filteredLocations, currentLocation);
                    var rangeList = GetRangeList(filteredLocations.Count);
                    rangeList.Add("X");

                    var val = ReadProperValue(rangeList);
                    Console.WriteLine("|" + val + "|");
                    if (val != "X")
                        currentLocation = filteredLocations[int.Parse(val)];
                }
                else
                {
                    if (currentLocation.NonPlayerCharacters != null)
                        TalkTo(new DialogParser(hero), currentLocation.NonPlayerCharacters[int.Parse(data)]);
                    Console.WriteLine("Naciśnij dowolny przycisk...");
                    Console.ReadKey();
                }
            }
            
            #endregion
        }
        
        private static void ShowLocations(IEnumerable<Location> locations, Location currentLocation)
        {
            var i = 0;
            Console.Clear();
            Console.WriteLine("Znajdujesz się w " + currentLocation.Name + ". Gdzie chcesz wyruszyć?");
            foreach (var location in locations)
                Console.WriteLine("[" + i++ + "] " + location.Name);
            Console.WriteLine("[X] Powrót");
        }

        private static void ExitIfX(string data, int exitCode=0)
        {
            if (data != "x" && data != "X")
                return;
            
            Console.Clear();
            Console.WriteLine("Naciśnij dowolny przycisk...");
            Console.ReadKey();
            Environment.Exit(exitCode);
        }

        private static Hero CreateHero()
        {
            var hero = new Hero();
            string name;
            
            Console.Clear();
            Console.WriteLine("Podaj poprawne imię (przynajmniej 3 znaki A-Za-z)...");
            
            var flag = false;
            do
            {
                if (flag)
                    Console.WriteLine("Błędne dane. Jeszcze raz...");
                name = Console.ReadLine();
                name = name?.Trim();
                flag = true;
            }
            while (!Hero.IsNameValid(name));

            hero.HeroName = name;
            
            Console.Clear();
            Console.WriteLine("Witaj " + hero.HeroName + ", wybierz klasę bohatera...");
            Console.WriteLine("[0] barbarzynca");
            Console.WriteLine("[1] paladyn");
            Console.WriteLine("[2] amazonka");

            var num = ReadProperValue(GetRangeList(3));
            hero.SetClass(num);

            return hero;
        }

        private static void ShowLocation(Location location)
        {
            var i = 0;
            Console.Clear();
            Console.WriteLine("Znajdujesz się w " + location.Name + ". Co chcesz zrobić?");
            if (location.NonPlayerCharacters != null)
                foreach (var npc in location.NonPlayerCharacters)
                {
                    Console.WriteLine("[" + i + "] Porozmawiaj z " + npc.Name);
                    ++i;
                }
            
            Console.WriteLine("[T] Podróżuj");
            Console.WriteLine("[X] Zamknij program");
        }

        private static List<string> GetRangeList(int length)
        {
            var list = new List<string>(length);

            for (var i = 0; i < length; ++i)
                list.Add(i.ToString());
            
            return list;
        }

        private static void TalkTo(IDialogParser dialogParser, NonPlayerCharacter npc)
        {
            var npcDialog = npc.StartTalking();
            Console.Clear();
            Console.WriteLine(npc.Name + ": " + dialogParser.ParseDialog(npcDialog));

            while (npcDialog?.HeroDialogPart != null)
            {
                npcDialog.PrintDialog(dialogParser);
                var data = ReadProperValue(GetRangeList(npcDialog.HeroDialogPart.Length));
                var heroDialog = npcDialog.HeroDialogPart[int.Parse(data)];
                Console.Clear();
                Console.WriteLine("Hero: " + dialogParser.ParseDialog(heroDialog));
                npcDialog = heroDialog.NpcDialogPart;
                if (npcDialog != null)
                    Console.WriteLine(npc.Name + ": " + dialogParser.ParseDialog(npcDialog));
            }
        }
        
        private static string ReadProperValue(List<string> listOfCorrectData)
        {
            string data;
            var flag = false;
            do
            {
                if (flag)
                {
                    Console.WriteLine();
                    Console.WriteLine("Błędne dane. Jeszcze raz...");
                }
                    
                data = Console.ReadLine()?.Trim().ToUpper();
                flag = true;
            }
            while (!listOfCorrectData.Contains(data));

            return data;
        }
    }
}