using System;

namespace EierfarmBl
{
    public class Ei
    {
        // Konstruktor für ein Ei
        public Ei(IEiLeger mutter)
        {
            Random random = new Random();
            this.Gewicht = random.Next(45, 81);
            this.Farbe = (EiFarbe)random.Next(Enum.GetNames(typeof(EiFarbe)).Length); // DirectCast - Exception, wenn Cast fehlschlägt
            this.Legedatum = DateTime.Now;
            this.Mutter = mutter;
        }

        public Ei(DateTime legedatum, IEiLeger mutter):this(mutter)
        {
            this.Legedatum = legedatum;
        }

        public IEiLeger Mutter { get; set; }

        // Auto-Property
        // Property mit autom. (durch den Compiler) generiertem Backing Field.
        public int Gewicht { get; set; }

        private DateTime _legedatum;

        // Ei ei = new Ei(); -> Konstruktor
        // ei.Legedatum = ... ; -> SET
        // DateTime datum = ei.Legedatum; -> GET
        public DateTime Legedatum
        {
            get { return _legedatum; }
            set { _legedatum = value; }
        }

        public EiFarbe Farbe { get; set; }
    }

    
    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}
