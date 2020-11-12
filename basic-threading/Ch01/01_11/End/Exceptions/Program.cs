using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo();
        }

        private static void Demo()
        {
            //https://www.c-sharpcorner.com/UploadFile/19b1bd/threading-simplified-part-6/
            new Thread(Execute).Start();
        }

        static void Execute()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {

            }

        }
    }
}
