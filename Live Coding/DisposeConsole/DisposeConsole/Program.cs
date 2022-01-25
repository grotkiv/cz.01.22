using System;
using System.Net.Sockets;
using System.Threading;

namespace DisposeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo1 = new DemoClass("Version 1");
            demo1.Dispose();

            string ergebnis = UseDemo();
            Console.WriteLine(ergebnis);

            // Garbage Collection erzwingen
            //Thread.Sleep(100);
            //GC.Collect();

            string ergebnis3 = UseUsing();
            Console.WriteLine(ergebnis3);
        }

        private static string UseDemo()
        {
            var demo2 = new DemoClass("Version 2");
            return "Version 2 erzeugt";
        }

        private static string UseUsing()
        {
            string result;
            try
            {
                using (var demo3 = new DemoClass("Version 3"))
                {
                    result = "Version 3 erzeugt";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }


    public class DemoClass : IDisposable
    {

        // Konstruktor
        public DemoClass(string name)
        {
            this.Name = name;
        }

        // Destruktor
        ~DemoClass()
        {
            Console.WriteLine($"Destructor von {this.Name}.");
        }

        // Nicht zulässig, ersetzen durch Destruktor
        //public static void Finalize()
        //{

        //}


        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"Dispose von {this.Name}.");

            Dispose(true);

            // TODO: Aufräumen!
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Client.Dispose();
            }
        }

        public TcpClient Client { get; set; }
    }
}
