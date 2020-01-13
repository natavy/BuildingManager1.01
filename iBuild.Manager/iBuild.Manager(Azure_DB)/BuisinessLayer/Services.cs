using Building.Manager.Model;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Building.Manager.Model.Task;

namespace BuisinessLayer
{
    public class Services
    {
        static IServiceRepository _repository;
        static Services()
        {
            _repository = new ServiceRepository();
        }

        public static List<Service> GetAll()
        {
            return _repository.GetAll();
        }

        public static Service GetById(int id)
        {
            return _repository.GetById(id);
        }
        public static Service GetServiceByOffer(int id)
        {
            return _repository.GetById(id);
        }
        public static Service GetOffer(int id)
        {
            return _repository.GetById(id);
        }
        public static Service Insert(Service obj)
        {

            return _repository.Insert(obj);
        }

        public static void Update(Service obj)
        {
            _repository.Update(obj);
        }

        public static void Delete(Service obj)
        {
            _repository.Delete(obj);
        }

        public static void SaveOffer(Offer obj)
        {
            _repository.SaveOffer(obj);
        }
        
        public static void SaveTask(Task obj)
        {
            _repository.SaveTask(obj);
        }

        public static void DeleteTask(Task obj)
        {
            _repository.DeleteTask(obj);
        }

        
    }
}
