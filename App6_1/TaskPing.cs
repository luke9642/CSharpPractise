using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace App6_1
{
    public class TaskPing
    {
        public List<string> Addresses { get; }
        
        public TaskPing(List<string> addresses)
        {
            Addresses = addresses;
        }

        public void PingAllData()
        {
            SemaphoreSlim ss = new SemaphoreSlim(4);
            List<Task> trackedTasks = new List<Task>();
            
            Addresses.ForEach(address =>
            {
                ss.Wait();
                trackedTasks.Add(Task.Run(() =>
                {
                    var pinger = new Ping();
                    var reply = pinger.Send(address);
                    Console.WriteLine(address + "  :  " + reply?.Status);
                }).ContinueWith(_ => { ss.Release(); }));
            });
            
            Task.WaitAll(trackedTasks.ToArray());
        }
    }
}