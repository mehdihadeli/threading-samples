using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualReset
{
    class Program
    {
        private static ManualResetEvent caztonEvent = 
            new ManualResetEvent(false);
        //private static EventWaitHandle cazton =
        //    new EventWaitHandle(false, EventResetMode.ManualReset);
        static void Main(string[] args)
        {
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);
            Console.WriteLine("Press a key to release all the threads so far");
            Console.ReadKey();
            caztonEvent.Set();
            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Threads won't block even if they call WaitOne");
            Console.ReadKey();
             Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Threads will block if they call WaitOne");
            Console.ReadKey();
            caztonEvent.Reset();
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Calls Set()");
            Console.ReadKey();
            caztonEvent.Set();
            Console.ReadLine();

        }

        private static void CallWaitOne()
        {
            Console.WriteLine(Task.CurrentId + " has called WaitOne");
            caztonEvent.WaitOne();
            Console.WriteLine(Task.CurrentId + " finally ended");
        }
    }
}
