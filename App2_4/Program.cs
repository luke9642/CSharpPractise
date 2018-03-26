using System;
 using System.Collections.Generic;
 using System.Linq;
 
 namespace App2_4
 {
     internal class Program
     {
         public static void Main(string[] args)
         {
             string city;
             var cities = new List<string>();
             do
             {
                 city = Console.ReadLine();
                 cities.Add(city);
             } while (city != "X");
 
             cities.Remove("X");
 
             var dict = cities.GroupBy(x => x.First(), x => x); //.OrderBy(x => x); //.ToDictionary(x => x.First(), x => x)
             
             
             
             foreach (var d in dict)
             {
                 Console.WriteLine(d);
             }
         }
     }
 }