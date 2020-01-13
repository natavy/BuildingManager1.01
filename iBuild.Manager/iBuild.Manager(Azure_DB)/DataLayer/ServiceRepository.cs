using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Manager.Model;
using Task = Building.Manager.Model.Task;


namespace DataLayer
{
    public class ServiceRepository : IServiceRepository
    {
        
        public List<Service> GetAll()
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                return db.Services.ToList();
            }
        }

        public Service GetById(int id)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                return db.Services.SingleOrDefault(s => s.Id == id);

            }
        }

        public Offer GetOffer(int id)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {

                return db.Offers.SingleOrDefault(o => o.Id == id);

            }
        }


        public Service Insert(Service record)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                db.Services.Add(record);
                db.SaveChanges();
                return record;
            }
        }

        public void Update(Service record)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                var service = db.Services.SingleOrDefault(s => s.Id == record.Id);
                service.Measure = record.Measure;
                service.Name = record.Name;
                service.Price = record.Price;
                db.SaveChanges();
            }
        }
        public void Delete(Service record)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                var service = db.Services.SingleOrDefault(s => s.Id == record.Id);
                db.Services.Remove(service);
                db.SaveChanges();
            }
        }

        public List<Service> GetServicesByOffer(int id)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                return db.Services.ToList();
            }
        }

        public Offer SaveOffer(Offer record)
        {
            using (BM_DatabaseEntities db = new BM_DatabaseEntities())
            {
                
                db.Offers.Add(record);
                db.SaveChanges();
                return record;
            }
        }
        
        public Task SaveTask(Task record)
        {
            using (BM_DatabaseEntities db=new BM_DatabaseEntities())
            {
                try
                {
                    
                    db.Tasks.Add(record);
                    db.SaveChanges();
                    
                }
                
                catch (DbEntityValidationException ee)
                {
                    foreach (var error in ee.EntityValidationErrors)
                    {
                        foreach (var thisError in error.ValidationErrors)
                        {
                            var errorMessage = thisError.ErrorMessage;
                        }
                    }
                
                }
                return record;
            }
        }

        public void DeleteTask(Task record)
        {
            using (BM_DatabaseEntities db=new BM_DatabaseEntities())
            {
                var task = db.Tasks.FirstOrDefault(t => t.Id == record.Id);
                db.Tasks.Attach(task);
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }
         
        
       
    }
}
