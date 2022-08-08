using ADOClassLibrary.InjectionsFolder;
using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using Autofac.Extras.Moq;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void TestMock()
        {
            // Create the mock
            //var mock = new Mock<IPerformer>();

            //// Configure the mock to do something
            //mock.SetupGet(x => x.MyProperty).Returns("FixedValue");

            //// Demonstrate that the configuration works
            //Assert.AreEqual("FixedValue", mock.Object.MyProperty);

            //// Verify that the mock was invoked
            //mock.VerifyGet(x => x.MyProperty);

            var mock = new Mock<IPerformer>();
            mock.Setup(x => x.GetAllOrders()).Returns(mockOrders());

            Assert.AreEqual(7, mock.Object.GetAllOrders().Count());

        }



        [Test]
        public void TestGetAllOrders()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPerformer>()
                    .Setup(x => x.GetAllOrders())
                    .Returns(mockOrders());

                var cls = mock.Create<IPerformer>();

               // Mock<IPerformer> p = new Mock<IPerformer>();
                List<Order> actual = cls.GetAllOrders();
                List<Order> expected = mockOrders();


                Assert.AreEqual(expected.Count(), actual.Count());
            }
            
        }
        [Test]
        public void TestInsertOrders()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Order ord = mockOrders()[0];

                mock.Mock<IPerformer>()
                    .Setup(x => x.InsertOrder(ord))
                    .Returns(1);

                var cls = mock.Create<IPerformer>();

                int res = cls.InsertOrder(ord);

                Assert.AreEqual(1, res);
            }
        }

        private List<Order> mockOrders()
        {
            List<Order> output = new List<Order>
            {
                new Order{ Id = 1, Status = "NotStarted", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 1 },
                new Order{ Id = 2, Status = "Loading", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 2 },
                new Order{ Id = 3, Status = "InProgress", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 3 },
                new Order{ Id = 4, Status = "Arrived", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 4 },
                new Order{ Id = 5, Status = "Unloading", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 5 },
                new Order{ Id = 6, Status = "Cancelled", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 6 },
                new Order{ Id = 7, Status = "Done", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 7 }
            };
            return output;
        }
    }
}