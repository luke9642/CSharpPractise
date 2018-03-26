using System;
using System.Collections.Generic;

namespace App1_1
{
    internal static class Program
    {
        public static void Main()
        {
            #region Intro

            Console.WriteLine("Witaj w grze Diablo");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[x] Zamknij program");

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

            var location = Factory.CreateLocationWithTwoNpcs();

            while (true)
            {
                ShowLocation(location);
                var list = GetRangeList(location.NonPlayerCharacters.Length);
                list.Add("x");
                data = ReadProperValue(list);
                ExitIfX(data);
                TalkTo(new DialogParser(hero), location.NonPlayerCharacters[int.Parse(data)]);
                Console.WriteLine("Naciśnij dowolny przycisk...");
                Console.ReadKey();
            }
            
            #endregion
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
            foreach (var npc in location.NonPlayerCharacters)
            {
                Console.WriteLine("[" + i + "] Porozmawiaj z " + npc.Name);
                ++i;
            }
            
            Console.WriteLine("[x] Zamknij program");
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
                    
                data = Console.ReadLine()?.Trim();
                flag = true;
            }
            while (!listOfCorrectData.Contains(data));

            return data;
        }
    }
}