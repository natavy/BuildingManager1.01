using Building.Manager.Model;
using BuisinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
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

namespace Building.Manager
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            ServiceUserControl.NewOfferAdded += ServiceUserControl_NewOfferAdded;
        }

        private void ServiceUserControl_NewOfferAdded(OfferService addedService)
        {
            OfferUserControl.AddNewService(addedService);
        }
    }
}