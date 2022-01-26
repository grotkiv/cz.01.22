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

namespace BummlerUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler = new Bummler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnBummeln_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                button.Content = "...";

                lblBummeln.Content = "";
                lblBummeln.Content = await bummler.BummelnAsync();

                lblStatusBummeln.Content = "Bummler bummelt.";

                button.Content = "Bummeln";
            }
        }

        private void btnTroedeln_Click(object sender, RoutedEventArgs e)
        {
            lblTroedeln.Content = "";

            //lblTroedeln.Content =  await bummler.TroedelnAsync();
            lblTroedeln.Content = bummler.Langweilen(); // Blockierender Aufruf

            lblStatusTroedeln.Content = "Bummler trödelt.";
        }

    }
}
