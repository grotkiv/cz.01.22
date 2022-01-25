using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace TradingDayDal
{
    /// <summary>
    /// A TradingDay.
    /// </summary>
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value);

            //CultureInfo ciEcb = new CultureInfo("en-US");
            //NumberFormatInfo nfiEcb = ciEcb.NumberFormat;

            NumberFormatInfo nfiEcb = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            var qCurrencies = tradingDayNode.Elements().Where(nd => CheckNodeName(nd, "Cube")
                                                                    //nd.Name.LocalName == "Cube"
                                                                    && nd.Attributes().Any(at => at.Name == "currency")
                                                                  && nd.Attributes().Any(at => at.Name == "rate"))
                                                     .Select(nd => new Currency()
                                                     {
                                                         Symbol = nd.Attribute("currency").Value,
                                                         EuroRate = Convert.ToDouble(nd.Attribute("rate").Value, nfiEcb)
                                                     });

            this.Currencies = qCurrencies.ToList();
        }

        private bool CheckNodeName(XElement elementToCheck, string name)
        {
            if (elementToCheck.Name.LocalName == name)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets or sets the date of this TradingDay
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Currencies of this TradingDay
        /// </summary>
        public List<Currency> Currencies { get; set; }
    }
}
