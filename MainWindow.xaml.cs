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
using System.Diagnostics;
using JAMK.IT;

namespace KitchenApp
{
  
    public partial class MainWindow : Window
    {
        private List<Aineet> aineet;
        private List<Reseptit> reseptit;
        public static MainWindow AppWindow;

        public MainWindow()
        {
            InitializeComponent();
            AlustaKontrollit();         
        }

        private void AlustaKontrollit()
        {
            try
            {
                aineet = DB.GetAineet();
                reseptit = DB.GetReseptit();
                AppWindow = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

     

        private void btnHae_Click(object sender, RoutedEventArgs e)
        {
            dgReseptiaineet.Visibility = Visibility.Hidden;
            dgAineet.Visibility = Visibility.Visible;
            dgAineet.ItemsSource = DB.GetAineet();
            btnKayta.IsEnabled = false;
            btnPuutteet.IsEnabled = false;
        }               

        private void btnHaeReseptit_Click(object sender, RoutedEventArgs e)
        {        
            try
            {
                dgReseptit.ItemsSource = DB.GetReseptit();
                dgReseptit.Visibility = Visibility.Visible;
                txbReseptiohje.Visibility = Visibility.Hidden;
                dgReseptiaineet.Visibility = Visibility.Hidden;
                dgAineet.Visibility = Visibility.Visible;
                btnKayta.IsEnabled = false;
                btnPuutteet.IsEnabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnLisaaAine_Click(object sender, RoutedEventArgs e)
        {
            LisaaAine ikkuna = new LisaaAine();
            ikkuna.ShowDialog();         
        }

        private void BtnOstoslista_Click(object sender, RoutedEventArgs e)
        {
            Ostoslista ikkuna = new Ostoslista();
            ikkuna.ShowDialog();
        }

        private void dgReseptit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgReseptiaineet.Visibility = Visibility.Visible;     // ohjelmaa käynnistettäessa kumpikin datagrid piilotettuna
            dgAineet.Visibility = Visibility.Hidden;
            dgReseptit.Visibility = Visibility.Hidden;
            txbReseptiohje.Visibility = Visibility.Visible;
            btnPuutteet.IsEnabled = true;           
            btnKayta.IsEnabled = true;

            Reseptit r = new Reseptit();
           
            r = (Reseptit)dgReseptit.SelectedItem;  // Tarvitsee kastata samantyyppiseksi olioksi jotta saadaan valitun reseptin nimi lähetettyä metodille
            if (r != null)
            {
                dgReseptiaineet.ItemsSource = DB.GetReseptiAineet(r.Nimi);
                txbReseptiohje.Text = DB.Reseptiohjeet(r.Nimi);          
            }
        }
        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            PoistaAine  ikkuna = new PoistaAine();

            Aineet a = new Aineet();
            Aineet b = new Aineet();
            a = (Aineet)dgAineet.SelectedItem;
            b = (Aineet)dgReseptiaineet.SelectedItem;
            if (a != null)
            {
                if (a != null && dgAineet.IsVisible)
                {
                    a = (Aineet)dgAineet.SelectedItem;
                    ikkuna.cmbAinebox.Text = a.Nimi;
                    ikkuna.ShowDialog();
                }
            }
            else if (b != null)
            {
                b = (Aineet)dgReseptiaineet.SelectedItem;
                ikkuna.cmbAinebox.Text = b.Nimi;
                ikkuna.ShowDialog();
            }
            else
            {
                ikkuna.ShowDialog();
            }
        }

        private void btnLisaaResepti_Click(object sender, RoutedEventArgs e)
        {
            LisaaReseptit ikkuna = new LisaaReseptit();
            ikkuna.ShowDialog();
        }

        private void btnPuutteet_Click(object sender, RoutedEventArgs e)
        {
            Puutteet ikkuna = new Puutteet();
            Reseptit r = new Reseptit();

            r = (Reseptit)dgReseptit.SelectedItem;
            if (r != null)
            {
                ikkuna.dgPuutteet.ItemsSource = DB.GetPuutteet(r.Nimi);
                ikkuna.ShowDialog();
            }
        }

        private void btnToteutettavatReseptit_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                dgReseptit.ItemsSource = DB.HaeToteutettavat();
                dgReseptit.Visibility = Visibility.Visible;
                txbReseptiohje.Visibility = Visibility.Hidden;
                dgReseptiaineet.Visibility = Visibility.Hidden;
                dgAineet.Visibility = Visibility.Visible;
                btnKayta.IsEnabled = false;
                btnPuutteet.IsEnabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            MuokkaaReseptit ikkuna = new MuokkaaReseptit();
            ikkuna.ShowDialog();            
        }

        private void btnKayta_Click(object sender, RoutedEventArgs e)
        {
            bool lippu = true;
            Reseptit r = new Reseptit();
            r = (Reseptit)dgReseptit.SelectedItem;

            reseptit = DB.VertaaPuutteet();

            foreach (var item in reseptit)
            {
                Debug.Write(item.Nimi);
                if(r.Nimi==item.Nimi)
                {
                    lippu = true;
                    break;
                }
                else
                {
                    lippu = false;
                }
            }

            if (lippu == false)
            {
                try
                {
                    Aineet a = new Aineet();
                    foreach (var item in dgReseptiaineet.Items)
                    {
                        a = (Aineet)item;
                        a.Maara = -a.Maara;
                        DB.MuokkaaAineita(a.Nimi, a.Maara);
                    }
                    MessageBox.Show("Tuotteet käytetty varastosta", "TUOTTEEET KÄYTETTY", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ei voi käyttää, aineissa puutteita", "PUUTTEITA AINEISSA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

       
    }
}

