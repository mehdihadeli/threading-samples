using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlinqForAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(2000, 5000);
            var query = list.AsParallel().Where(x => x % 25 == 0);
            //var orderedQuery = list.AsParallel().AsOrdered().Where(x => x % 25 == 0);
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            query.ForAll(x => concurrentBag.Add(x));
            Console.WriteLine(concurrentBag.Count);
        }
    }
}
