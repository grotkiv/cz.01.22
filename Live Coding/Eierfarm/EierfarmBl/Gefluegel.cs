using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEiLeger, INotifyPropertyChanged
    {
        public event EventHandler EigenschaftGeaendert;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnEigenschaftGeaendert()
        {
            //if (EigenschaftGeaendert != null)
            //{
            //    EigenschaftGeaendert(this, new EventArgs());
            //}
            EigenschaftGeaendert?.Invoke(this, new EventArgs());
        }

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Gefluegel(string name)
        {
            this.Name = name;
        }

        public DateTime Schluepfdatum { get; private set; }

        private int _gewicht;

        public int Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }

        // Auto-Property-Initializer
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }

        public abstract void EiLegen();
        public abstract void Fressen();

        public void Flattern()
        { }
    }
}
