using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuationWithState
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(() => DoSomething());
            List<Task<DateTime>> continuationTasks 
                = new List<Task<DateTime>>();
            for(int i = 0; i < 3; i++)
            {
                task = task.ContinueWith((x, y) => DoSomething(), new Person { Id = i });
                continuationTasks.Add(task);
            }
            task.Wait();

            foreach (var continuation in continuationTasks)
            {
                Person person = continuation.AsyncState as Person;
                Console.WriteLine("Task finished at " + continuation.Result + ". Person id is {0}", person.Id);

            }
        }

        public static DateTime DoSomething()
        {
            return DateTime.Now;
        }
    }
}
