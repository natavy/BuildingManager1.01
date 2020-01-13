using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Building.Manager.Annotations;

namespace Building.Manager.Models
{
    public class OfferServiceViewModel : INotifyPropertyChanged
    {
        private int _quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public int OfferId { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string ServiceMeasure { get; set; }

        public decimal ServicePrice { get; set; }
         
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        public decimal Amount => ServicePrice * Quantity;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
