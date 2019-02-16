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
    /// Interaction logic for LisaaResepti.xaml
    /// </summary>
    public partial class LisaaReseptit : Window
    {
        public static LisaaReseptit AppWindow;
        private List<Reseptit> reseptit;
        private List<string> haaste = new List<string>();
        bool lippu;

        public LisaaReseptit()
        {
            InitializeComponent();
            AlustaKontrollit();
        }
        private void AlustaKontrollit()
        {
            reseptit = DB.GetReseptit ();
            dgAineet.ItemsSource = DB.GetAineet();
            AppWindow = this;
            haaste.Add("Helppo");
            haaste.Add("Keskivaikea");
            haaste.Add("Vaikea");
            cmbHaaste.ItemsSource = haaste;
        }
        private List<Aineet> CheckBox_Checked()  // Haetaan rastitetut aineet ja tallennetaan listaan
        {
            var SelectedList = new List<Aineet>();
            for (int i = 0; i < dgAineet.Items.Count; i++)
            {
                if(dgAineet.Items[i] is Aineet)
                {
                    var item = dgAineet.Items[i];
                    var mycheckbox = dgAineet.Columns[0].GetCellContent(item) as CheckBox;
                    if((bool)mycheckbox.IsChecked)
                    {
                        SelectedList.Add((Aineet)dgAineet.Items[i]);                    
                    }
                }
            }
            return SelectedList;
        }
        
        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {
            List<Aineet> L = new List<Aineet>();    
            L = CheckBox_Checked(); 
            try
            {
                if (txtNimi.Text.Length * txtValmistusaika.Text.Length != 0 && cmbHaaste.SelectedValue != null && txtOhje.Text.Length != 0)
                {
                    Reseptit resepti = new Reseptit();
                    resepti.Nimi = txtNimi.Text;
                    resepti.Haaste = cmbHaaste.SelectedValue.ToString();
                    resepti.Valmistusaika = int.Parse(txtValmistusaika.Text);
                    resepti.Ohje = txtOhje.Text;

                    if (DB.LisaaResepti(resepti, L))
                    {
                        MessageBox.Show("Resepti " + resepti.Nimi + " lisätty", "TUOTTEEN LISÄYS", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Reseptin lisääminen epäonnistui", "TUOTTEEN LISÄYS", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void txtValmistusaika_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                   
                        MessageBox.Show("Vain numeraalisia arvoja (esim 20)", "Tarkasta määrä", MessageBoxButton.OK);
                        lippu = true;
                    
                }
            }
        }
        private void txtValmistusaika_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lippu == true)
            {

                txtValmistusaika.Text = "";
                lippu = false;
            }
        }

        private void txtOhje_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "";
        }
    }
}

