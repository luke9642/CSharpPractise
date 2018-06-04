using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace App6_1
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                var addresses = File.ReadLines("../../ping.txt");
                var sequencePing = new TaskPing(addresses.ToList());
            
                var stopwatch = Stopwatch.StartNew();
                sequencePing.PingAllData();
                stopwatch.Stop();
            
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}