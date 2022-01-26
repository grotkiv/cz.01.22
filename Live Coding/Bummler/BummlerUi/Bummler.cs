using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BummlerUi
{
    public class Bummler
    {
        public string Bummeln()
        {
            double res = Wurzelsumme(2000000000);
            return $"Fertig mit Bummeln ({res:f2}).";
        }

        public async Task<string> BummelnAsync()
        {
            double res = await Task.Run(() => Wurzelsumme(200000000));
            return $"Fertig mit Bummeln ({res:f2}).";
        }

        public string Troedeln()
        {
            double res = Wurzelsumme(4000000000);
            return $"Fertig mit Troedeln ({res:f2}).";
        }

        public async Task<string> Langweilen()
        {
            double res = await Task.Run(() => Wurzelsumme(200000000));
            return "Langeweile zu Ende.";
        }

        public async Task<string> TroedelnAsync()
        {
            double res = await Task.Run(() => Wurzelsumme(400000000));
            return $"Fertig mit Troedeln ({res:f2}).";
        }

        private double Wurzelsumme(Int64 max)
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
