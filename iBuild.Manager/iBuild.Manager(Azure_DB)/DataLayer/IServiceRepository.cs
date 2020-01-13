using Building.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Building.Manager.Model.Task;

namespace DataLayer
{
   public interface IServiceRepository
    {
        List<Service> GetAll();
        Service GetById(int id);
        Service Insert(Service record);
        void Update(Service record);
        void Delete(Service record);
        List<Service> GetServicesByOffer(int id);
        Offer GetOffer(int id);
        Offer SaveOffer(Offer record);
        Task SaveTask(Task record);
        void DeleteTask(Task record);
    }
}
