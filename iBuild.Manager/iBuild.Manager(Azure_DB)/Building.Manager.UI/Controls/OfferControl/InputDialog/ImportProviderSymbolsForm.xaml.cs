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

namespace Building.Manager.InputDialog
{
   
    public partial class ImportProviderSymbolsForm : Window
    {
        public ImportProviderSymbolsForm()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Box_OfferName.SelectAll();
            Box_OfferName.Focus();
            Box_Description.SelectAll();
            Box_Description.Focus();
           
        }

        public string NameField
        {
            get { return Box_OfferName.Text; }
           
        }

        public string DescriptionField
        {
            get { return Box_Description.Text; }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
