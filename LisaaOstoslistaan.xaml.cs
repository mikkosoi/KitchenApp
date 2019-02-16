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
    
    public partial class LisaaOstoslistaan : Window
    {
        public LisaaOstoslistaan()
        {
            InitializeComponent();
            AlustaKontrollit();
        }

        private List<Aineet> aineet;
        bool lippu = false;       

        private void AlustaKontrollit()
        {
            aineet = DB.GetAineet();            
            cmbMittayksikko.ItemsSource = Varasto.Mittayksikot(aineet);            
        }
        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                if (txtNimi.Text.Length * txtMaara.Text.Length != 0 && cmbMittayksikko.SelectedValue != null)
                {

                    System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
                    float x;
                    
                    Aineet aine = new Aineet();
                    aine.Nimi = txtNimi.Text;
                    float.TryParse(txtMaara.Text,out x);
                    aine.Maara = x;
                    aine.Mittayksikko = cmbMittayksikko.SelectedItem.ToString();                   

                    if (DB.LisaaOstoslistaan(aine))
                    {                    
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
                    if ( e.Key != Key.OemComma)
                    {
                       MessageBox.Show("Vain numeraalisia arvoja (esim 4)", "Tarkasta määrä", MessageBoxButton.OK);
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
    }
}
