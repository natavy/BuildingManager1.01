using CrystalDecisions.CrystalReports.Engine;
using System.Windows;

namespace Building.Manager
{

    public partial class PrintWindow : Window
    {
                
        public PrintWindow()
        {
            
            InitializeComponent();
        }

        public void LinkReport(ReportDocument cr)

        {
            crystalReportsViewer.ViewerCore.ReportSource = cr;

         }
        
    }
}

