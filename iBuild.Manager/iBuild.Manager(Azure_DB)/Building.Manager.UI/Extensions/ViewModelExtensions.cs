using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Manager.Controls.Schedule;
using Building.Manager.Model;
using Building.Manager.Models;
using Task = Building.Manager.Model.Task;

namespace Building.Manager.Extensions
{
    public static class ViewModelExtensions
    {
        public static OfferServiceViewModel ToViewModel(this OfferService offerService)
        {
            return new OfferServiceViewModel()
            {
                OfferId = offerService.OfferId,
                ServiceId = offerService.ServiceId,
                ServiceName = offerService.Service.Name,
                ServiceMeasure = offerService.Service.Measure,
                ServicePrice = offerService.Service.Price,
                Quantity = offerService.Quantity,
            };
        }
        public static OfferService ToDbModel(this OfferServiceViewModel offerserviceViewModel)
        {
            return new OfferService()
            {
                OfferId = offerserviceViewModel.OfferId,
                ServiceId = offerserviceViewModel.ServiceId,
                Quantity = offerserviceViewModel.Quantity,
                Amount=offerserviceViewModel.Amount,
            };
        }
 }
}
