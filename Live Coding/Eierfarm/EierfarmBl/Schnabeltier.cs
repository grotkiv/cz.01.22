using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public sealed class Schnabeltier : Saeugetier, IEiLeger
    {
        public ObservableCollection<Ei> Eier { get; set; }
        public int Gewicht { get; set; }

        public void EiLegen()
        {
            Ei ei = new Ei(this);
            this.Eier.Add(ei);
        }

        public void Fressen()
        {
            this.Gewicht+=450;
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}