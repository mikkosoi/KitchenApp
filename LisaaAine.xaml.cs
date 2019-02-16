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

    public partial class LisaaAine : Window
    {
        private List<Aineet> aineet;
        bool lippu = false;
        public LisaaAine()
        {
            InitializeComponent();
            AlustaKontrollit();
            
        }

        private void AlustaKontrollit()
        {
            aineet = DB.GetAineet();
            dpParastaEnnen.SelectedDate = DateTime.Today;
            cmbMittayksikko.ItemsSource = Varasto.Mittayksikot(aineet);
        }
        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {
            var aika = dpParastaEnnen.SelectedDate.Value;                      
            string date = aika.ToString("yyyy-MM-dd");

            try
            {
                if (txtNimi.Text.Length * txtMaara.Text.Length  != 0)
                {
                    Aineet aine = new Aineet();
                    aine.Nimi = txtNimi.Text;
                    aine.Maara = float.Parse(txtMaara.Text);
                    aine.Mittayksikko = cmbMittayksikko.SelectedItem.ToString();
                    aine.ParastaEnnen = date;

                    if (DB.LisaaAineita(aine))
                    {
                        MessageBox.Show("Tuote " + aine.Nimi + " lisätty", "TUOTTEEN LISÄYS", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tuotteen lisääminen epäonnistui", "TUOTTEEN LISÄYS", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Tarkista syöte, jokin kentistä on tyhjä", "VIRHE", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            MainWindow.AppWindow.dgAineet.ItemsSource = DB.GetAineet();
        }

        private void btnPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void txtMaara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.OemComma)
                    {
                        MessageBox.Show("Vain numeraalisia arvoja (esim 1.5)", "Tarkasta määrä", MessageBoxButton.OK);
                        lippu = true;
                    }
                }
            }
        }


        private void txtMaara_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lippu == true)
            {
               
                txtMaara.Text = "";
                lippu = false;
            }
        }

        private void TarkistaNumerot()
        {
            if (txtMaara.Text.Contains("")) { }

        }

    }

}
