using System;
using System.Linq;

namespace App2_2
{
    class Program
    {
        static void Main()
        {
            int.TryParse(Console.ReadLine(), out var n);
            var squares = Enumerable.Range(1, n).Where(x => x != 5 && x != 9 && (x%7 == 0 || x%2 != 0)).Select(x => x*x).ToList();

            Console.WriteLine("Elements: ");
            squares.ForEach(Console.WriteLine);
            
            Console.Write("Sum: ");
            Console.WriteLine(squares.Sum());
            
            Console.Write("Count: ");
            Console.WriteLine(squares.Count);

            Console.Write("First: ");
            Console.WriteLine(squares.First());
            
            Console.Write("Last: ");
            Console.WriteLine(squares.Last());
            
            Console.Write("Third: ");
            Console.WriteLine(squares.ElementAt(2));
        }
    }
}