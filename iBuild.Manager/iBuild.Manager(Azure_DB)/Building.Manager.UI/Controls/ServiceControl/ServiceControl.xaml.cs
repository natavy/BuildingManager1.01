using Building.Manager.Controls.ServiceControl;
using Building.Manager.Model;
using Building.Manager.Models;
using BuisinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
   
    public partial class ServiceControl : UserControl
    {

        private readonly IServiceRepository _repositoryDataContext;
        private ServiceViewModel _serviceDataContext;
       
        public ServiceControl()
        {

            _serviceDataContext = new ServiceViewModel();
            _serviceDataContext.Services = new ObservableCollection<Service>();
            _serviceDataContext.SaveServiceCommand = new SaveServiceCommand(InsertService);
            _serviceDataContext.DeleteServiceCommand = new DeleteServiceCommand(DeleteService);
            _serviceDataContext.EditServiceCommand = new EditServiceCommand(EditService);
            _serviceDataContext.UpdateServiceCommand = new UpdateServiceCommand(UpdateService);
            _serviceDataContext.AddToOfferCommand = new AddToOfferCommand(AddToOffer);
            _serviceDataContext.ExportServicesCommand = new ExportServicesCommand(ExportServices);
           

            InitializeComponent();
            this.DataContext = _serviceDataContext;
            

        }

        
        public event Action<OfferService> NewOfferAdded;

        private ObservableCollection<OfferService> offerServices = new ObservableCollection<OfferService>();
        public void AddToOffer(Service service)
        {
            Service selectedService = (Service)serviceList.SelectedItem;
            var newOfferservice = new OfferService()
            {
                ServiceId = selectedService.Id,
                Service = selectedService
            };
            offerServices.Add(newOfferservice);

            //tuk raise-vame eventa che neshto se e  sluchilo. W sluchaia bila e dobavena nova oferta
            NewOfferAdded?.Invoke(newOfferservice);

            MessageBox.Show("Добавен в офертата!");

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }


        public void Refresh()
        {
            var services = new ObservableCollection<Service>(Services.GetAll());
            serviceList.ItemsSource = services;
        }

        private void Clear_Boxes()
        {
            Box_ID.Clear();
            Box_Name.Clear();
            Box_Measure.Clear();
            Box_Price.Clear();

        }
        public void InsertService(Service service)
        {
            Service newService = new Service();
            newService.Name = Box_Name.Text;
            newService.Price = Convert.ToDecimal(Box_Price.Text);
            newService.Measure = Box_Measure.Text;
            if (String.IsNullOrEmpty(Box_Name.Text)|| String.IsNullOrEmpty(Box_Price.Text)|| String.IsNullOrEmpty(Box_Measure.Text))
            {
                MessageBox.Show("Трябва да въведете всички полета!");
                return;
                
            }
           
            
            Services.Insert(newService);
            MessageBox.Show("Успешно добавен запис!");
            Refresh();
            Clear_Boxes();
        }

        public void DeleteService(Service service)
        {
            Service selectedService = (Service)serviceList.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Сигурни ли сте, че искате да изтриете този запис?", "Изтриване на запис", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Services.Delete(selectedService);
            }
            Refresh();
            if (messageBoxResult == MessageBoxResult.No)
            {
                Clear_Boxes();
            }
        }
        public void EditService(Service service)
        {
            Service serviceToEdit = (Service)serviceList.SelectedItem;
            Box_ID.Text = serviceToEdit.Id.ToString();
            Box_Name.Text = serviceToEdit.Name.ToString();
            Box_Price.Text = serviceToEdit.Price.ToString();
            Box_Measure.Text = serviceToEdit.Measure.ToString();
        }
       

        public void UpdateService(Service service)
        {
            Service serviceToUpdate = (Service)serviceList.SelectedItem;
            serviceToUpdate.Id = Convert.ToInt32(Box_ID.Text);
            serviceToUpdate.Name = Box_Name.Text;
            serviceToUpdate.Price = Convert.ToDecimal(Box_Price.Text);
            serviceToUpdate.Measure = Box_Measure.Text;
            Services.Update(serviceToUpdate);
            MessageBox.Show("Успешно редактиран запис!");
            Refresh();
            Clear_Boxes();
        }


        public void ExportServices(Service service)
        {
            DataGrid dg = serviceList;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String Clipboardresult = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            StreamWriter swObj = new StreamWriter("Services.csv", false, Encoding.UTF8);
            swObj.WriteLine(Clipboardresult);
            swObj.Close();
            Process.Start("Services.csv");
        }

        private void Box_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(serviceList.ItemsSource);
            view.Filter = s => (s as Service).Name.ToLower().Contains((sender as TextBox).Text);
            
            //ICollectionView cv = CollectionViewSource.GetDefaultView(serviceList.ItemsSource);
            //var searchtext = Box_Search.Text;
            //string filter = searchtext;
            //if (filter == "")
            //{
            //    cv.Filter = null;
            //}
            //else
            //{
            //    cv.Filter = o =>
            //    {
            //        Service p = o as Service;
            //        if (searchtext == "txtId")
            //            return (p.Id == Convert.ToInt32(filter));
            //        return (p.Name.ToUpper().StartsWith(filter.ToUpper()));
            //    };
            //}

        }
    }
}
