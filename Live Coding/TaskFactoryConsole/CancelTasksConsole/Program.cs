using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTasksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task<double> t1 = new Task<double>(() => WurzelsummeFault(200000000, token));
            Task<double> t2 = new Task<double>(() => Wurzelsumme(300000000, token));

            Console.WriteLine("<Enter>, um Tasks zu starten.");
            Console.WriteLine("Nochmal <Enter> zum Canceln der Tasks.");

            Console.ReadLine();

            try
            {
                t1.Start();
                t2.Start();

                Console.ReadLine();

                tokenSource.Cancel();
                Console.WriteLine("Breche Tasks ab.");

                Console.WriteLine($"Task 1: {t1.Result:f2}, Task 2: {t2.Result:f2}");

            }
            catch (AggregateException ex)
            {

                Console.WriteLine($"AggregateException: {ex.Message}");

                foreach (Exception item in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Da klappte etwas nicht: {ex.Message}");
            }
        }


        private static double Wurzelsumme(Int64 max, CancellationToken token)
        {
            double result = 0;
            for (Int64 i = 0; i < max; i++)
            {
                //if (token.IsCancellationRequested)
                //{
                //    throw new OperationCanceledException("Wurzelsumme canceled.");
                //}
                token.ThrowIfCancellationRequested();


                result = result + Math.Sqrt(i);
            }

            return result;
        }

        private static double WurzelsummeFault(Int64 max, CancellationToken token)
        {
            double result = 0;
            for (Int64 i = 0; i < max; i++)
            {
                //if (token.IsCancellationRequested)
                //{
                //    throw new OperationCanceledException("Wurzelsumme canceled.");
                //}
                token.ThrowIfCancellationRequested();

                if (i == 501)
                {
                    throw new Exception("Fehler 501!");
                }

                result = result + Math.Sqrt(i);
            }

            return result;
        }

    }
}
