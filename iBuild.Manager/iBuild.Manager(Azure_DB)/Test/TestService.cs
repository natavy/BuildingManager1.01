using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Input;
using Building.Manager.Model;
using Building.Manager.Models;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestClass]
    public class TestService
    {
        private Mock<IServiceRepository> mock;
        private List<Service> services { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {

            services = new List<Service>();
            mock = new Mock<IServiceRepository>();
            mock.Setup(m => m.GetAll()).Returns(services);
            mock.Setup(m => m.Insert(It.IsAny<Service>())).Callback<Service>(record => services.Add(record));
            mock.Setup(m => m.Delete(It.IsAny<Service>())).Callback<Service>(record => services.Remove(record));
            mock.Setup(m => m.Update(It.IsAny<Service>())).Callback<Service>(record =>
                                                                                        {
                                                                                            int i = services.IndexOf(record);                                                                                            services[i] = record;                                                                               });

        }

        [TestMethod]
        public void SaveCommandCannotExecuteWhenNameIsNotValid()
        {
            var viewModel = new ServiceViewModel()
            {
                ServiceRecord = new Service
                {
                    Name = null,
                    Measure="m2",
                    Price=2.0m
                    
                }
            };
            Assert.Throws<NullReferenceException>(() => viewModel.SaveServiceCommand.CanExecute(null));
        }

       [TestMethod]
       public void SaveCommandCannotExecuteWhenMeasureIsNotValid()
        {
            var viewModel = new ServiceViewModel()
            {
                ServiceRecord = new Service
                {
                    Name = "Boqdisvane",
                    Measure = null,
                    Price = 2.0m

                }
            };
            Assert.Throws<NullReferenceException>(() => viewModel.SaveServiceCommand.CanExecute(null));

        }
        [TestMethod]
        public void SaveCommandCannotExecuteWhenPriceIsNotValid()
        {
            var viewModel = new ServiceViewModel()
            {
                ServiceRecord = new Service
                {
                    Name = "Boqdisvane",
                    Measure = "m2",
                    Price = Convert.ToDecimal(null)

                }
            };
            Assert.Throws<NullReferenceException>(() => viewModel.SaveServiceCommand.CanExecute(null));

        }



        //[TestMethod]
        //public void SaveCommandServicesPropertyWithExpectedCollectionFromDataStore()
        //{

        //    var viewModel = new ServiceViewModel();
        //    mock.Object.Insert(new Service { Name = "Boqdisvane", Measure = "m2", Price = 2.0m });
        //    mock.Object.Insert(new Service { Name = "Kartene", Measure = "m2", Price = 5.5m });
        //    mock.Object.Insert(new Service { Name = "Dograma", Measure = "m2", Price = 12.0m });

        //    viewModel.SaveServiceCommand.Execute(null);

        //    Assert.IsTrue(viewModel.Services.Count == 3);

        //}


        //[TestMethod]
        //public void CountSavedServisesInDatabase()
        //{
        //    var modelView = new ServiceViewModel();
        //    services = new List<Service>()
        //    {
        //        new Service { Id = 3, Name = "Boqdisvane", Price = 25, Measure = "m2" },
        //        new Service { Id = 21, Name = "Izolaciq", Price = 60, Measure = "m3" },
        //        new Service { Id = 34, Name = "Mazilka", Price = 45, Measure = "m" },
        //        new Service { Id = 5, Name = "Kurtene", Price = 76, Measure = "m2" },
        //        new Service { Id = 344, Name = "Zamaska", Price = 23, Measure = "m3" },

        //     };

        //    Assert.IsTrue(modelView.Services.Count == 5);

        }

    }
