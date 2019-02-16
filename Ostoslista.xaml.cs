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

    public partial class Ostoslista : Window
    {
        public static Ostoslista AppWindow;
        private List<Aineet> lista;
        public Ostoslista()
        {
            InitializeComponent();
            lista = DB.GetOstoslista();
            dgOstoslista.ItemsSource = lista;
            AppWindow = this;
        }
        private void btnOPeruuta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLisaaOstoslistaan_Click(object sender, RoutedEventArgs e)
        {
            LisaaOstoslistaan ikkuna = new LisaaOstoslistaan();
            ikkuna.ShowDialog();
            dgOstoslista.ItemsSource = DB.GetOstoslista();
        }

        private void btnPoistaOstoslistasta_Click(object sender, RoutedEventArgs e)
        {

            Valinta ikkuna = new Valinta();
            ikkuna.ShowDialog();           
       
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)  //valitsee datagridin ensimmäisen rivin sen latautuessa
        {
            {
                DataGrid dataGrid = sender as DataGrid;
                dataGrid.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
