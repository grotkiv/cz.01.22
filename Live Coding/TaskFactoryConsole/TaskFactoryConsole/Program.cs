using System;
using System.Threading.Tasks;

namespace TaskFactoryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<double> t1 = Task.Factory.StartNew<double>(() => Wurzelsumme(200000000));
            Task<double> t2 = Task.Factory.StartNew<double>(() => Wurzelsumme(300000000));

            Console.WriteLine($"Task 1: {t1.IsCompleted}, Task 2: {t2.IsCompleted}");

            //t1.Wait();
            //t2.Wait();

            Task.WaitAll(t1, t2);
            Console.WriteLine($"Task 1: {t1.IsCompleted}, Task 2: {t2.IsCompleted}");
            Console.WriteLine($"Task 1: {t1.Result:f4}, Task 2: {t2.Result:f4}");

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
