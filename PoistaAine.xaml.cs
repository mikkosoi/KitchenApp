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
using System.Diagnostics;

namespace KitchenApp
{
    /// <summary>
    /// Interaction logic for PoistaAine.xaml
    /// </summary>
    public partial class PoistaAine : Window
    {
        private List<Aineet> aineet;
        public PoistaAine()
        {
            InitializeComponent();
            AlustaKontrollit();
           
        }
        private void AlustaKontrollit()
        {
            aineet = DB.GetAineet();
            cmbAinebox.ItemsSource = Ainelistat.Ainelista(aineet);
            cmbAinebox.SelectedIndex = 0;
        }


        private void btnPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbAinebox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {        
                txbMittayksikko.Text = DB.Yksikot(cmbAinebox.SelectedValue.ToString());
        }

        private void btnVahenna_Click(object sender, RoutedEventArgs e)
        {
            float c;
            if (float.TryParse(txtMaara.Text, out c))
            {
                string b = cmbAinebox.SelectedItem.ToString();
                if (b != null)
                {
                    c = -c;
                    DB.MuokkaaAineita(b, c);
                    //cmbAinebox.ItemsSource = DB.GetAineet();
                    MessageBox.Show("Vähennys onnistui", "TUOTTEEN VÄHENNYS", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMaara.Text = String.Empty;
                    MainWindow.AppWindow.dgAineet.ItemsSource = DB.GetAineet();

                }
            }
            else
            {
                MessageBox.Show("Syötteeseen kelpaa vain numerot", "VIRHE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {
            float c;
            if (float.TryParse(txtMaara.Text, out c))
            {
                string b = cmbAinebox.SelectedItem.ToString();
                if (b != null)
                { 
                    DB.MuokkaaAineita(b, c);
                    //cmbAinebox.ItemsSource = DB.GetAineet();
                    MessageBox.Show("Lisäys onnistui", "TUOTTEEN LISÄYS", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMaara.Text = String.Empty;
                    MainWindow.AppWindow.dgAineet.ItemsSource = DB.GetAineet();
                }
            }
            else
            {
                MessageBox.Show("Syötteeseen kelpaa vain numerot", "VIRHE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Haluatko varmasti poistaa tuotteen?", "VARMISTUS", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            switch (result)
            {
                case MessageBoxResult.OK:
                    string a = cmbAinebox.SelectedItem.ToString();
                    if (a != null)
                    {
                        DB.PoistaAineita(a);
                    }
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
            MainWindow.AppWindow.dgAineet.ItemsSource = DB.GetAineet();
        }
    }
}
