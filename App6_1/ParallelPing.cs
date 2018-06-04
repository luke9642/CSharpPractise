using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace App6_1
{
    public class ParallelPing
    {
        public List<string> Addresses { get; }
        
        public ParallelPing(List<string> addresses)
        {
            Addresses = addresses;
        }

        public void PingAllData()
        {
            var parallelAdresses = Addresses.AsParallel().WithDegreeOfParallelism(4);
            parallelAdresses.ForAll(address =>
            {
                var pinger = new Ping();
                var reply = pinger.Send(address);
                Console.WriteLine(address + "  :  " + reply?.Status);
            });
        }
    }
}