using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TasksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            Stopwatch stopwatch = Stopwatch.StartNew();

            long t1elapsed = 0;
            long t2elapsed = 0;
            long t3elapsed = 0;

            tasks[0] = Task.Run(() => { Wurzelsumme(200000000); t1elapsed = stopwatch.ElapsedMilliseconds; });
            tasks[1] = Task.Run(() => { Wurzelsumme(300000000); t2elapsed = stopwatch.ElapsedMilliseconds; });
            tasks[2] = Task.Run(() =>
              {

                  Wurzelsumme(200000000);
                  Wurzelsumme(100000000);
                  t3elapsed = stopwatch.ElapsedMilliseconds;
              });

            Task.WaitAll(tasks);
            Console.WriteLine($"Task 1 brauchte {t1elapsed}ms.");
            Console.WriteLine($"Task 2 brauchte {t2elapsed}ms.");
            Console.WriteLine($"Task 3 brauchte {t3elapsed}ms.");

            Console.WriteLine("Status:");
            foreach (Task item in tasks)
            {
                Console.WriteLine($"   Task {item.Id}: {item.Status}");
            }
        }

        private static double Wurzelsumme(Int64 max)
        {
            double result = 0;
            for (Int64 i = 0; i < max; i++)
            {
                result = result + Math.Sqrt(i);
            }

            return result;
        }

    }
}
