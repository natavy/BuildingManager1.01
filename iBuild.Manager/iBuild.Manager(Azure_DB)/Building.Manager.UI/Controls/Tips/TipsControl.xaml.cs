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
    /// <summary>
    /// Interaction logic for TipsControl.xaml
    /// </summary>
    public partial class TipsControl : UserControl
    {
        public TipsControl()
        {
            InitializeComponent();
        }

        private void Button_TipsClick(object sender, RoutedEventArgs e)
        {
            WindowTips window = new WindowTips();
            window.Show();
        }
    }
}
