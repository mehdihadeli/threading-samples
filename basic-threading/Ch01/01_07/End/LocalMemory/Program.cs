using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Worker Thread
            new Thread(PrintOneToThirty).Start();

            //Main Thread
            PrintOneToThirty();
        }

        private static void PrintOneToThirty()
        {
            // i variable here is local variable, it will be part of the local memory of that particular thread
            // each thread has it own local memory for local variable
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + 1 + " ");
            }
        }
    }
}
