using ADOClassLibrary.InterfaceImplementationFolder;
using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void productPerformer_GetAllProducts()
        {

            var connectionProvider = new Mock<IConnectionController>();
            connectionProvider.Setup(x => x.GetConnection()).Returns(new SqlConnection()).Verifiable();
            connectionProvider.Setup(x => x.OpenConnection()).Verifiable();
            connectionProvider.Setup(x => x.BeginTransaction()).Verifiable();
            connectionProvider.Setup(x => x.Reader.Read()).Returns(true);

            IProductPerformer productPerformer = new ProductPerformer(connectionProvider.Object);

            productPerformer.GetAllProducts();

            connectionProvider.Verify();
        }
        [Test]
        public void orderPerformer_GetAllProducts()
        {

            var connectionProvider = new Mock<IConnectionController>();
            connectionProvider.Setup(x => x.GetConnection()).Returns(new SqlConnection()).Verifiable();
            connectionProvider.Setup(x => x.InitializeDataAdapter()).Verifiable();
            connectionProvider.Setup(x => x.InitializeDataSet()).Verifiable();
            connectionProvider.Setup(x => x.FillDataSet()).Verifiable();


            IOrderPerformer orderPerformer = new OrderPerformer(connectionProvider.Object);
            orderPerformer.GetAllOrders();

            connectionProvider.Verify();
        }

        private IDataReader MockIDataReader(List<Product> ojectsToEmulate)
        {
            var moq = new Mock<IDataReader>();

            int count = -1;

            moq.Setup(x => x.Read())
                .Returns(() => count < ojectsToEmulate.Count - 1)
                .Callback(() => count++);

            moq.Setup(x => x["Id"])
                .Returns(() => ojectsToEmulate[count].Id);
            moq.Setup(x => x["Description"])
                .Returns(() => ojectsToEmulate[count].Description);
            moq.Setup(x => x["Height"])
                .Returns(() => ojectsToEmulate[count].Height);
            moq.Setup(x => x["Weight"])
                .Returns(() => ojectsToEmulate[count].Weight);
            moq.Setup(x => x["Length"])
                .Returns(() => ojectsToEmulate[count].Length);
            moq.Setup(x => x["Width"])
                .Returns(() => ojectsToEmulate[count].Width);

            return moq.Object;
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
        private List<Product> mockProducts()
        {
            List<Product> output = new List<Product>
            {
                new Product{ Id = 1, Description = "Description 1", Height = 1, Weight = 1, Length = 1, Width = 1 },
                new Product{ Id = 2, Description = "Description 2", Height = 2, Weight = 2, Length = 2, Width = 2 },
                new Product{ Id = 3, Description = "Description 3", Height = 3, Weight = 3, Length = 3, Width = 3 },
                new Product{ Id = 4, Description = "Description 4", Height = 4, Weight = 4, Length = 4, Width = 4 },
                new Product{ Id = 5, Description = "Description 5", Height = 5, Weight = 5, Length = 5, Width = 5 },

            };
            return output;
        }

        private DataSet mockDataSet()
        {
            DataSet ds = new DataSet("MyDataset");


            DataTable dt = new DataTable("Orders");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            dt.Columns.Add("UpdatedDate", typeof(DateTime));
            dt.Columns.Add("ProductId", typeof(int));

            DataRow dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Status"] = "Loading";
            dr["CreatedDate"] = DateTime.Now;
            dr["UpdatedDate"] = DateTime.Now;
            dr["ProductId"] = 123;
            dt.Rows.Add(dr);

            DataRow dr2 = dt.NewRow();
            dr["Id"] = 2;
            dr["Status"] = "InProgress";
            dr["CreatedDate"] = DateTime.Now;
            dr["UpdatedDate"] = DateTime.Now;
            dr["ProductId"] = 456;
            dt.Rows.Add(dr2);

            ds.Tables.Add(dt);

            return ds;
        }
    }
}