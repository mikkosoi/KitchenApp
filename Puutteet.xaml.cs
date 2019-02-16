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
    
    public partial class Puutteet : Window
    {
        public Puutteet()
        {
            InitializeComponent();
        }
        private void btnOPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {
            if (dgPuutteet.Items.IsEmpty)
            {
                MessageBox.Show("Ei lisättäviä tuotteita", "Ostoslista tyhjä", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                foreach (var item in dgPuutteet.Items)
                {
                    DB.LisaaOstoslistaan((Aineet)item);
                }
                MessageBox.Show("Tuotteet lisätty ostoslistalle", "Lisätty ostoslistalle", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

    
    }
}
