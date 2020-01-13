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

namespace Building.Manager.Controls
{
    
    public partial class InstrumentsControl : UserControl
    {
        public InstrumentsControl()
        {
            InitializeComponent();
        }
        private void Button_Click_Instruments(object sender, RoutedEventArgs e)
        {
            WindowPriceCalculator windowPrice = new WindowPriceCalculator();
            windowPrice.Show();
        }

    }
}
