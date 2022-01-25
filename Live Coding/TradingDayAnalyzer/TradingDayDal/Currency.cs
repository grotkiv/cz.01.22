namespace TradingDayDal
{
    /// <summary>
    /// Stellt eine Währung dar.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gibt den Eurokurs der Währung zurück oder legt ihn fest.
        /// </summary>
        /// <remarks>
        /// 1 EUR = EuroRate
        /// </remarks>
        public double EuroRate { get; set; }

        /// <summary>
        /// Stellt das 3-buchstabige ISO-Zeichen der Währung dar.
        /// </summary>
        public string Symbol { get; set; }
    }
}