using Building.Manager.Model;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Building.Manager.Models
{
    public class ServiceViewModel
    {

       

        public ObservableCollection<Service> Services { get; set; }
        public ICommand SaveServiceCommand { get; set; }
        public ICommand DeleteServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }
        public ICommand UpdateServiceCommand { get; set; }
        public ICommand SearchServiceCommand { get; set; }
        public ICommand AddToOfferCommand { get; set; }
        public ICommand ExportServicesCommand { get; set; }
        public Service ServiceRecord { get; set; }
        

        public ServiceViewModel()
        {
            Services = new ObservableCollection<Service>();
        }

    }
}
