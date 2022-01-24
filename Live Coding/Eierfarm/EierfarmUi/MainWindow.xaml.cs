using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EierfarmUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = new Huhn();

            huhn.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void Gefluegel_EigenschaftGeaendert(object sender, EventArgs e)
        {
            // TODO: Controls updaten
            // Oboslet, weil WPF-Architektur bereits (fast) alles mitbringt.
        }

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();
            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnNeuesSchnabeltier_Click(object sender, RoutedEventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTiere.Items.Add(schnabeltier);
            cbxTiere.SelectedItem = schnabeltier;
        }

        private void btnFressen_Click(object sender, RoutedEventArgs e)
        {
            IEiLeger tier = cbxTiere.SelectedItem as IEiLeger;

            //if (tier!=null)
            //{
            //    tier.Fressen();
            //}
            tier?.Fressen();
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            int? a = null;
            System.Nullable<Int32> a1 = null;
            int b = (a.HasValue ? a.Value : -1);
            int b1 = a ?? -1;


            if (cbxTiere.SelectedItem is IEiLeger tier)
            {
                tier.EiLegen();
            }

            //((IEiLeger)cbxTiere.SelectedItem)?.EiLegen();
        }
    }
}
