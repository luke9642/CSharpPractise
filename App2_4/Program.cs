using System;
 using System.Collections.Generic;
 using System.Linq;
 
 namespace App2_4
 {
     internal static class Program
     {
         public static void Main()
         {
             string city;
             var cities = new List<string>();
             do
             {
                 city = Console.ReadLine();
                 cities.Add(city);
             } while (city != "X");
 
             cities.Remove("X");
 
             var dict = cities
                 .GroupBy(x => x.First(), x => x)
                 .ToDictionary(elem => elem.Key, elem => elem.OrderBy(x => x).ToList());
             
             while (true)
             {
                 var key = char.Parse(Console.ReadLine() ?? throw new Exception("Złe dane"));
                 Console.WriteLine(dict.ContainsKey(key) ? dict[key].Aggregate((a, b) => a + ", " + b) : "PUSTE");
             }
         }
     }
 }