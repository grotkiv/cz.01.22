using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[200 * 1000 * 1000];

            for (int i = 0; i < array.Length; i++)
                array[i] = 1;


            for (int i = 0; i < 3; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Serial(array, 2);
                Console.WriteLine("Serial: {0:f2} s", sw.Elapsed.TotalSeconds);

                //sw = Stopwatch.StartNew();
                //ParallelFor(array, 2);
                //Console.WriteLine("ParallelFor: {0:f2} s", sw.Elapsed.TotalSeconds);

                //sw = Stopwatch.StartNew();
                //ParallelForOptions(array, 2);
                //Console.WriteLine("ParallelForOptions: {0:f2} s", sw.Elapsed.TotalSeconds);

                //sw = Stopwatch.StartNew();
                //CustomParallel(array, 2);
                //Console.WriteLine("CustomParallel: {0:f2} s", sw.Elapsed.TotalSeconds);

                sw = Stopwatch.StartNew();
                Partitioned(array, 2);
                Console.WriteLine("Partitioned: {0:f2} s", sw.Elapsed.TotalSeconds);


            }
        }

        static void Serial(double[] array, double factor)
        {
            // double sum=0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * factor;
                //  sum += array[i];
            }
        }

        static void ParallelFor(double[] array, double factor)
        {
            Parallel.For(
                0,
                array.Length,
                i =>
                {
                    array[i] = array[i] * factor;
                });
        }

        static void ParallelForOptions(double[] array, double factor)
        {
            ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.For(
                    0,
                    array.Length,
                    options,
                    i =>
                    {
                        array[i] = array[i] * factor;
                    });

        }

        static void CustomParallel(double[] array, double factor)
        {
            var degreeOfParallelism = Environment.ProcessorCount;

            var tasks = new Task[degreeOfParallelism];

            for (int taskNumber = 0; taskNumber < degreeOfParallelism; taskNumber++)
            {
                // capturing taskNumber in lambda wouldn't work correctly
                int taskNumberCopy = taskNumber;

                tasks[taskNumber] = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = array.Length * taskNumberCopy / degreeOfParallelism;
                            i < array.Length * (taskNumberCopy + 1) / degreeOfParallelism;
                            i++)
                        {
                            array[i] = array[i] * factor;
                        }
                    });
            }

            Task.WaitAll(tasks);
        }

        static void Partitioned(double[] array, double factor)
        {
            var partitioner = Partitioner.Create(0, array.Length);

            Parallel.ForEach(partitioner, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    array[i] = array[i] * factor;
                }
            }
            );
        }
    }
}
