using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PLinqDegreeParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> websites = new List<string>();
            websites.Add("www.apple.com");
            websites.Add("www.google.com");
            websites.Add("www.microsoft.com");

            List<PingReply> responses =
                websites.AsParallel()
                .WithDegreeOfParallelism(websites.Count)
                .Select(PingSites).ToList();

            foreach (var response in responses)
            {
                Console.WriteLine("Address "  + response.Address 
                    + " Status - " + response.Status + " Time taken: " 
                    + response.RoundtripTime);
            }
            Console.ReadLine();
        }

        private static PingReply PingSites(string websiteName)
        {
            Ping ping = new Ping();
            return ping.Send(websiteName);
        }
    }
}
