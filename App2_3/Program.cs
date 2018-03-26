using System;
using System.Linq;

namespace App2_3
{
    internal static class Program
    {
        public static void Main()
        {
            var random = new Random();
            
            int.TryParse(Console.ReadLine(), out var n);
            int.TryParse(Console.ReadLine(), out var m);

            var listsList = Enumerable.Range(0, m).Select(x => Enumerable.Range(0, n).Select(y => random.Next(100)).ToList()).ToList();
            
            Console.Write("Elements:");
            listsList.ForEach(list => list.ForEach(x => Console.Write(x + ", ")));
            Console.WriteLine();
            
            Console.Write("All: ");
            Console.WriteLine(listsList.SelectMany(x => x).Sum());
        }
    }
}