using Building.Manager.Model;
using BuisinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace Building.Manager.Controls
{
    
    public partial class ArchiveControl : UserControl
    {
        public ArchiveControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                
                        var q = from pd in db.Offers
                        join od in db.OfferServices on pd.Id equals od.OfferId
                        join sd in db.Services on od.ServiceId equals sd.Id
                        orderby pd.Name ascending
                        group new
                        {
                            ServiceId=sd.Id,
                            ServiceName=sd.Name,
                            ServiceMeasure=sd.Measure,
                            ServicePrice=sd.Price,
                            ServiceQuantity=od.Quantity,
                            ServiceAmount=od.Amount
                            
                     } by pd into servicesByOffers
                        select new
                        {
                            OfferId=servicesByOffers.Key.Id, 
                            OfferCreated=servicesByOffers.Key.CreatedDate,
                            OfferName=servicesByOffers.Key.Name,
                            OfferDescription=servicesByOffers.Key.Description,
                            OfferTotal=servicesByOffers.Key.Total,
                            Services = servicesByOffers
                        }; 
                
                offerList.ItemsSource = q.ToList();
                

            }
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            offerList.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;

        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            offerList.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
        }

        
    }

    

}

        
