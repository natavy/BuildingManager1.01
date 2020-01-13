using System;
using System.Collections.Generic;
using Building.Manager.Model;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace Test
{
    
    [TestFixture]
    public class TestRepository
    {
       [Test]
        public void TestInsertMethod()
        {
            var mock = new Mock<IServiceRepository>();
            var itemsInserted =mock.Object;
            mock
                .Setup(i => i.Insert(It.IsAny<Service>()))
                .Callback((Service service) => itemsInserted.Insert(service));            
        }

        [Test]
        public void TestGetAllRepositoryMethod()
        {
            var mock1 = new Mock<IServiceRepository>();
            var result = mock1.Object;
            mock1.Setup(g => g.GetAll()).Returns(Fakecollection);

        }

        [Test]
        public void TestGetByIdRepositoryMethod()
        {
            var mockgetbyid = new Mock<IServiceRepository>();
            var result = mockgetbyid.Object;
            mockgetbyid.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Service { Id = 3, Name = "Boqdisvane", Price = 25, Measure = "m2" });

        }

        [Test]

        public void TestUpdateRepositoryMethod()
        {

            var mockupdate = new Mock<IServiceRepository>();
            var result = mockupdate.Object;
            mockupdate.Setup(u=> u.Update(It.IsAny<Service>())).Verifiable();

        }

        [Test]

        public void TestDeleteRepositoryMethod()
        {
            var deletemock = new Mock<IServiceRepository>();
            var result = deletemock.Object;
            deletemock
                .Setup(d => d.Delete(It.IsAny<Service>())).Callback<Service>(s => s.Id = 0);
        }

        [Test]

        public void TestGetOfferByIdRepositoryMethod()
        {
            var mockoffer = new Mock<IServiceRepository>();
            var result = mockoffer.Object;
            mockoffer.Setup(g => g.GetServicesByOffer(It.IsAny<int>())).Returns(Fakecollection);

        }


        protected List<Service> Fakecollection { get; set; }
        private void FakeData()
        {
            Fakecollection = new List<Service>
            {
                new Service{Id=3, Name="Boqdisvane", Price=25, Measure="m2"},
                new Service{Id=21, Name="Izolaciq", Price=60, Measure="m3"},
                new Service{Id=34, Name="Mazilka", Price=45, Measure="m"},
                new Service{Id=5, Name="Kurtene", Price=76, Measure="m2"},
                new Service{Id=344, Name="Zamaska", Price=23, Measure="m3"},

            };
        }
    }
}
