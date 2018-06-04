using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace App6_1
{
    public class SequencePing
    {
        public List<string> Addresses { get; }
        
        public SequencePing(List<string> addresses)
        {
            Addresses = addresses;
        }

        public void PingAllData()
        {
            var pinger = new Ping();
            try
            {
                Addresses.ForEach(address =>
                {
                    var reply = pinger.Send(address);
                    Console.WriteLine(address + "  :  " + reply?.Status);
                });
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
        }
    }
}