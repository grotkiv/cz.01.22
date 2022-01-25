using NUnit.Framework;
using System;
using System.Linq;
using TradingDayDal;

namespace TradingDayDalTests
{
    public class ArchiveTests
    {
        string url;

        [SetUp]
        public void Setup()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [Test]
        public void IsArchiveInitialising()
        {
            Archive archive = new Archive(url);

            TradingDay firstDay = archive.TradingDays.FirstOrDefault();
            Currency curUsd = firstDay?.Currencies.Find(cu => cu.Symbol == "USD");    //.Where(cu => cu.Symbol == "USD").FirstOrDefault();

            Console.WriteLine($"{curUsd.Symbol}: {curUsd.EuroRate:f4}");

            Assert.AreEqual(GetCountOfTimeAttributes(), archive.TradingDays.Count);
        }

        private int GetCountOfTimeAttributes()
        {
            return 64;
        }

        [Test]
        public void IsIsNumericWorking()
        {
            string test1 = "ABC";
            string test2 = "123";

            Assert.IsFalse(test1.IsNumeric());
            Assert.IsTrue(test2.IsNumeric());
        }
    }
}