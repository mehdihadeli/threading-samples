using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 100000000).ToArray();
            CancellationTokenSource cancellationTokenSource =
                new CancellationTokenSource();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            Console.WriteLine("Press 'x' to cancel");

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'x')
                {
                    cancellationTokenSource.Cancel();
                }
            });

            long total = 0;
            try
            {
                Parallel.For<long>(0, list.Length, parallelOptions, () => 0, (count, parallelLoopState, subtotal) =>
                {
                    //Thread.Sleep(200);
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                    subtotal += list[count]; // 0 + 1 + 2 + ...... 9 = 45
                    return subtotal;
                },
                (x) =>
                {
                    Interlocked.Add(ref total, x);
                });
            }
            catch(OperationCanceledException e)
            {
                Console.WriteLine("Cancelled Cazton " + e.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
            Console.WriteLine("The final sum is {0}", total);
        }
    }
}
