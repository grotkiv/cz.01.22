using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TradingDayDal
{
    public class Archive
    {
        /// <summary>
        /// New instance of an Archive
        /// </summary>
        /// <param name="url">URL of a GESMES XML file.</param>
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        private List<TradingDay> GetData(string url)
        {

            XDocument document = XDocument.Load(url);

            var q = document.Root.Descendants()
                                    .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                                    // Projektion
                                    .Select(xe => new TradingDay(xe)); // { Date = Convert.ToDateTime(xe.Attribute("time").Value) }));
                                    
                                    // Projektion auf Anonymous Type mit Date- + Count-Property
                                    //.Select(xe => new { Date= Convert.ToDateTime(xe.Attribute("time").Value), Count=xe.Elements().Count() });


            List<TradingDay> days = q.ToList();

            return days;

            //List<TradingDay> days = new List<TradingDay>();
            //days = q;

            //foreach (XElement item in q)
            //{
            //    TradingDay day = new TradingDay()
            //    {
            //        Date = Convert.ToDateTime(item.Attribute("time").Value),
            //        Currencies = null
            //    };

            //    days.Add(day);
            //}

            //return days;
        }

        //private List<TradingDay> GetDataByXmlReader(string url)
        //{
        //    XmlReader reader = XmlReader.Create(url);

        //    while (reader.Read())
        //    {
        //        if (reader.Name == "Cube" && reader["time"])
        //        {

        //        }
        //    }
        //}


        /// <summary>
        /// The TradingDays maintained by this Archive.
        /// </summary>
        public List<TradingDay> TradingDays { get; set; }
    }
}
