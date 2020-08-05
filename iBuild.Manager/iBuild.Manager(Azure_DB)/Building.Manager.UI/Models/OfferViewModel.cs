using Building.Manager.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Building.Manager.Models
{
    public class OfferViewModel: INotifyPropertyChanged
    {
        public int OfferId { get; set; }
        public ICommand CalculateOfferCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand SaveOfferCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        
        
        public ObservableCollection<OfferServiceViewModel> OfferServices { get; set; }

        
        private decimal _subtotal;
        public decimal SubTotal
        {
            get { return _subtotal; }
            set
            {
                if (value != _subtotal)
                {
                    _subtotal = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SubTotal));
                }
            }
        }
        private decimal _vat;

        public decimal Vat
        {
            get { return _vat; }
            set
            {
                if (value != _vat)
                {
                    _vat = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Vat));
                }
            }
        }

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                if (value != _total)
                {
                    _total = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Total));

                }
            }
        }
        public OfferViewModel()
        {
            OfferServices = new ObservableCollection<OfferServiceViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
