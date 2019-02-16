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
using System.Windows.Shapes;
using JAMK.IT;

namespace KitchenApp
{
    /// <summary>
    /// Interaction logic for Valinta.xaml
    /// </summary>
    public partial class Valinta : Window
    {
        public Valinta()
        {
            InitializeComponent();
        }


        private void btnKaikki_Click(object sender, RoutedEventArgs e)
        {
            DB.PoistaKaikkiOstoslistasta();
            Ostoslista.AppWindow.dgOstoslista.ItemsSource = DB.GetOstoslista();
            this.Close();
        }

        private void btnYksi_Click(object sender, RoutedEventArgs e)
        {
            Aineet a = new Aineet();
            a = (Aineet)Ostoslista.AppWindow.dgOstoslista.SelectedItem;
            if (a != null)
            {
                DB.PoistaOstoslistasta(a.AineID);
                Ostoslista.AppWindow.dgOstoslista.ItemsSource = DB.GetOstoslista();
            }
            this.Close();
        }

        private void btnPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
