using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public abstract class Saeugetier
    {
        public DateTime Geburtsdatum { get; set; }
        public string Name { get; set; }

        public abstract void Saeugen();
    }
}