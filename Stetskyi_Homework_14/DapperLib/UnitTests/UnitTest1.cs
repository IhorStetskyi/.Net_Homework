using NUnit.Framework;
using DapperLib.DALInterfaces;
using DapperLib.DALInterfaceImplementation;
using Autofac.Extras.Moq;
using DapperLib.Models;
using System.Collections.Generic;
using System;
using Moq;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void SelectOrders_Test()
        {
            string sql = @"select
                            [Id],
                            [Status],
                            [CreatedDate],
                            [UpdatedDate],
                            [ProductId] from Orders";

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConnectionController>()
                    .Setup(x => x.LoadData<Order>(sql))
                    .Returns(mockOrders());

                var orderController =  mock.Create<OrderController>();
                var expected = mockOrders();
                var actual = orderController.GetAllOrders();

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Id, actual[i].Id);
                    Assert.AreEqual(expected[i].Status, actual[i].Status);
                    Assert.AreEqual(expected[i].CreatedDate, actual[i].CreatedDate);
                    Assert.AreEqual(expected[i].UpdatedDate, actual[i].UpdatedDate);
                    Assert.AreEqual(expected[i].ProductId, actual[i].ProductId);
                }
            }
             
        }
        [Test]
        public void InsertOrder_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Order ord = mockOrders()[0];
                string sql = @"insert into [Orders]
                                        ([Status],
                                        [CreatedDate], 
                                        [UpdatedDate], 
                                        [ProductId])
                                        values(@Status, 
                                                @CreatedDate, 
                                                @UpdatedDate, 
                                                @ProductId)";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.SaveData<Order>(sql, ord));

                var orderController = mock.Create<OrderController>();
                orderController.InsertOrder(ord);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.SaveData<Order>(sql, ord), Times.Exactly(1));

            }
        }
        [Test]
        public void UpdateOrder_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Order ord = new Order { Id = 1, Status = "Done",
                    CreatedDate = new DateTime(2010, 05, 09),
                    UpdatedDate = new DateTime(2010, 05, 09),
                    ProductId = 1 };

                string sql = @"update [Orders]
                            set [Status] = @Status, 
                                [CreatedDate] = @CreatedDate, 
                                [UpdatedDate] = @UpdatedDate, 
                                [ProductId] = @ProductId
                                where Id = @Id;";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.UpdateData<Order>(sql, ord));

                var orderController = mock.Create<OrderController>();
                orderController.UpdateOrder(ord);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.UpdateData<Order>(sql, ord), Times.Exactly(1));

            }
        }
        //for some reason fails
        [Test]
        public void DeleteOrder_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                int orderId = 1;
                Order ord = new Order { Id = orderId };
                string sql = @"delete from [Orders]
                           where Id = @Id;";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.DeleteData<Order>(sql, ord));

                var orderController = mock.Create<OrderController>();
                orderController.DeleteOrder(orderId);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.DeleteData<Order>(sql, ord), Times.Exactly(1));

            }
        }

        [Test]
        public void SelectProducts_Test()
        {
            string sql = @"select [Id],
                            [Description],
                            [Weight],
                            [Height],
                            [Width],
                            [Length] from Products";

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConnectionController>()
                    .Setup(x => x.LoadData<Product>(sql))
                    .Returns(mockProducts());
                
                var productController = mock.Create<ProductController>();
                var expected = mockProducts();
                var actual = productController.GetAllProducts();

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Id, actual[i].Id);
                    Assert.AreEqual(expected[i].Description, actual[i].Description);
                    Assert.AreEqual(expected[i].Weight, actual[i].Weight);
                    Assert.AreEqual(expected[i].Height, actual[i].Height);
                    Assert.AreEqual(expected[i].Width, actual[i].Width);
                    Assert.AreEqual(expected[i].Length, actual[i].Length);
                }
            }

        }
        [Test]
        public void InsertProduct_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Product prod = mockProducts()[0];
                string sql = @"insert into [Products] 
                                        ([Description], 
                                        [Weight], 
                                        [Height], 
                                        [Width], 
                                        [Length])
                                        values (@Description, 
                                                @Weight, 
                                                @Height, 
                                                @Width, 
                                                @Length)";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.SaveData<Product>(sql, prod));

                var productController = mock.Create<ProductController>();
                productController.InsertProduct(prod);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.SaveData<Product>(sql, prod), Times.Exactly(1));

            }
        }
        [Test]
        public void UpdateProduct_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Product prod = new Product
                {
                    Id = 1,
                    Description = "Updated Description",
                    Weight = 1,
                    Height = 1,
                    Width = 1,
                    Length = 1
                };

                string sql = @"update [Products]
                            set [Description] = @Description,
                                [Weight] = @Weight,
                                [Height] = @Height,
                                [Width] = @Width,
                                [Length] = @Length
                                where Id = @Id;";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.UpdateData<Product>(sql, prod));

                var productController = mock.Create<ProductController>();
                productController.UpdateProduct(prod);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.UpdateData<Product>(sql, prod), Times.Exactly(1));

            }
        }
        //for some reason failss
        [Test]
        public void DeleteProduct_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                int productId = 1;
                Product prod = new Product { Id = productId };
                string sql = @"delete from [Products]
                           where Id = @Id;";

                mock.Mock<IConnectionController>()
                    .Setup(x => x.DeleteData<Product>(sql, prod));

                var productController = mock.Create<OrderController>();
                productController.DeleteOrder(productId);

                mock.Mock<IConnectionController>()
                    .Verify(x => x.DeleteData<Product>(sql, prod), Times.Exactly(1));

            }
        }


        private static List<Order> mockOrders()
        {
            List<Order> output = new List<Order>
            {
                new Order{ Id = 1, Status = "NotStarted", CreatedDate = new DateTime(2010,05,09), UpdatedDate = new DateTime(2010,05,09), ProductId = 1 },
                new Order{ Id = 2, Status = "Loading", CreatedDate = new DateTime(2011,05,09), UpdatedDate = new DateTime(2011,05,09), ProductId = 2 },
                new Order{ Id = 3, Status = "InProgress", CreatedDate = new DateTime(2012,05,09), UpdatedDate = new DateTime(2012,05,09), ProductId = 3 },
                new Order{ Id = 4, Status = "Arrived", CreatedDate = new DateTime(2013,05,09), UpdatedDate = new DateTime(2013,05,09), ProductId = 4 },
                new Order{ Id = 5, Status = "Unloading", CreatedDate = new DateTime(2014,05,09), UpdatedDate = new DateTime(2014,05,09), ProductId = 5 },
                new Order{ Id = 6, Status = "Cancelled", CreatedDate = new DateTime(2015,05,09), UpdatedDate = new DateTime(2015,05,09), ProductId = 6 },
                new Order{ Id = 7, Status = "Done", CreatedDate = new DateTime(2016,05,09), UpdatedDate = new DateTime(2016,05,09), ProductId = 7 }
            };
            return output;
        }
        private List<Product> mockProducts()
        {
            List<Product> output = new List<Product>
            {
                new Product{ Id = 1, Description = "Description 1", Height = 1, Weight = 1, Length = 1, Width = 1 },
                new Product{ Id = 2, Description = "Description 2", Height = 2, Weight = 2, Length = 2, Width = 2 },
                new Product{ Id = 3, Description = "Description 3", Height = 3, Weight = 3, Length = 3, Width = 3 },
                new Product{ Id = 4, Description = "Description 4", Height = 4, Weight = 4, Length = 4, Width = 4 },
                new Product{ Id = 5, Description = "Description 5", Height = 5, Weight = 5, Length = 5, Width = 5 }

            };
            return output;
        }
    }
}