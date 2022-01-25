using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDayDal
{
    public static class StringExtensionMethods
    {
        public static bool IsNumeric(this string text)
        {
            if (double.TryParse(text, out double zahl))
            {
                return true;
            }

            return false;
        }
    }
}
