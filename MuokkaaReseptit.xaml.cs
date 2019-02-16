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
using System.Diagnostics;
using JAMK.IT;


namespace KitchenApp
{
   
    public partial class MuokkaaReseptit : Window
    {
        private List<Reseptit> reseptit;
        
        public MuokkaaReseptit()
        {
            InitializeComponent();
            AlustaKontrollit();           
        }

        private void AlustaKontrollit()
        {
            reseptit = DB.GetReseptit();
            cmbReseptit.ItemsSource = Varasto.Resepti(reseptit);
            cmbReseptit.SelectedIndex = 0;
        }    

        private void btnPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbReseptit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nimi = cmbReseptit.SelectedValue.ToString();            
            if (nimi != null)
            {
                dgReseptiaineet.ItemsSource = DB.GetReseptiAineet(nimi);
                txtOhje.Text = DB.Reseptiohjeet(nimi);
            }
        }

        private void btnTallenna_Click(object sender, RoutedEventArgs e) 
        {
            
            if (cmbReseptit.SelectedValue.ToString() != null)
            {
                Reseptit recipe = new Reseptit();                   //recipe oliossa vain reseptin nimi ja ohjeteksti
                recipe.Nimi = cmbReseptit.SelectedValue.ToString();
                recipe.Ohje = txtOhje.Text;

                var ainelista = new List<Aineet>();

                for (int i = 0; i < dgReseptiaineet.Items.Count; i++)  //luetaan aineet listaan
                {
                    ainelista.Add((Aineet)dgReseptiaineet.Items[i]);                    
                }

                DB.TallennaResepti(recipe, ainelista);
                MessageBox.Show("Reseptin tallennus onnistui", "OK", MessageBoxButton.OK, MessageBoxImage.Information); 
            }
            else
            {
                MessageBox.Show("Ei valittua reseptiä", "HUOMIO", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            string nimi = cmbReseptit.SelectedValue.ToString();
            var result = MessageBox.Show(String.Format("Haluatko varmasti poistaa reseptin {0}?", nimi), "VARMISTUS", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            switch (result)
            {
                case MessageBoxResult.OK:
                   
                    if (nimi != null)
                    {
                        if (DB.PoistaResepti(nimi))  // poistetaan resepti tietokannasta ja päivitetään MainWindown resepti ja aineet ikkunat
                        {
                            MessageBox.Show("Reseptin poisto onnistui", "Tapahtuma onnistunui", MessageBoxButton.OK, MessageBoxImage.Information);
                            cmbReseptit.ItemsSource = Varasto.Resepti(reseptit);
                            MainWindow.AppWindow.dgReseptit.ItemsSource = DB.GetReseptit();
                            MainWindow.AppWindow.txbReseptiohje.Visibility = Visibility.Hidden;
                            MainWindow.AppWindow.dgReseptiaineet.Visibility = Visibility.Hidden;
                            MainWindow.AppWindow.dgReseptit.Visibility = Visibility.Visible;
                            MainWindow.AppWindow.dgAineet.Visibility = Visibility.Visible;                           
                            this.Close();                            
                        }
                        else
                        {
                            MessageBox.Show("Virhe");
                        }
                    }
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        }   
    }  
}