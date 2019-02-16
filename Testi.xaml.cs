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
    public partial class Testi : Window
    {
        
        public Testi()
        {
            InitializeComponent();
            AlustaKontrollit();
        }
        List<string> colors = new List<string>();

        private void AlustaKontrollit()
        {
            
            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Green");
        }
        private void btnHaasteet_Click(object sender, RoutedEventArgs e)
        {
           

            cmbHaasteet.ItemsSource = colors;
        }
    }
}
