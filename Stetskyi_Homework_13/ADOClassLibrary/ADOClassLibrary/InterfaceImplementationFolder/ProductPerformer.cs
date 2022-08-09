using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOClassLibrary.InterfaceImplementationFolder
{
    public class ProductPerformer : IProductPerformer
    {
        private readonly IConnectionProvider connectionProvider;
        public SqlConnection Connection { get; set; }
        public SqlCommand CMD { get; set; }
        public ProductPerformer(IConnectionProvider connectionprovider)
        {
            connectionProvider = connectionprovider;
        }

        #region Methods to create and delete stored procedures
        public void CreateStoredProcedure_CreateAndFillProductsTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"CREATE PROCEDURE CreateAndFillProductsTable
                                        AS
                                        BEGIN
	                                        IF OBJECT_ID ('Products') IS NOT NULL
		                                        BEGIN
                                                    ALTER TABLE Orders
                                                    DROP CONSTRAINT FK_Orders_Product
			                                        DROP TABLE [Products];
		                                        END
		                                        BEGIN
			                                        CREATE TABLE [dbo].[Products] (
			                                        [Id] INT IDENTITY (1, 1),
			                                        [Description] NVARCHAR (150),
			                                        [Weight]  DECIMAL,
			                                        [Height] DECIMAL,
			                                        [Width] DECIMAL,
			                                        [Length] DECIMAL);

			                                        alter table [Products]
			                                        add constraint PK_Products primary key (Id)
		                                        END
		                                        BEGIN
			                                        insert into [Products] ([Description], [Weight], [Height], [Width], [Length])
			                                        values 
			                                        ('Some description of 1-st Product', 10.5, 15.3, 111, 1111),
			                                        ('Some description of 2-d Product', 12.5, 5.65, 222.1, 200),
			                                        ('Some description of 3-d Product', 33.3, 65.1, 33333.20, 3),
			                                        ('Some description of 4-th Product', 35.7, 62.8, 21, 42),
			                                        ('Some description of 5-th Product', 18.7, 128, 44.1, 67.2)
		                                        END
                                        END", Connection);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Failed to create Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
                }
            }
        }



        //public void CreateStoredProcedure_CreateProductsTable()
        //{
        //    using (Connection = connectionProvider.GetConnection())
        //    {
        //        CMD = new SqlCommand(@"CREATE PROCEDURE CreateProductsTable
        //                                AS
        //                                BEGIN
	       //                                 IF OBJECT_ID ('Products') IS NOT NULL
		      //                                  BEGIN
			     //                                   DROP TABLE [Products];
		      //                                  END
		      //                                  BEGIN
			     //                                   CREATE TABLE [dbo].[Products] (
			     //                                   [Id] INT IDENTITY (1, 1),
			     //                                   [Description] NVARCHAR (150),
			     //                                   [Weight]  DECIMAL,
			     //                                   [Height] DECIMAL,
			     //                                   [Width] DECIMAL,
			     //                                   [Length] DECIMAL);

			     //                                   alter table [Products]
			     //                                   add constraint PK_Products primary key (Id)
		      //                                  END
        //                                END", Connection);
        //        try
        //        {
        //            Connection.Open();
        //            CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        //            CMD.ExecuteNonQuery();
        //            CMD.Transaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            CMD.Transaction.Rollback();
        //            throw new Exception($"Failed to create Stored Procedure CreateProductsTable, \nReason: {e.Message}");
        //        }
        //    }
        //}
        //public void CreateStoredProcedure_FillProductsTable()
        //{
        //    using (Connection = connectionProvider.GetConnection())
        //    {
        //        CMD = new SqlCommand(@"CREATE PROCEDURE CreateAndFillProductsTable
        //                                AS
        //                                BEGIN
	       //                                 IF OBJECT_ID ('Products') IS NOT NULL
		      //                                  BEGIN
			     //                                   DROP TABLE [Products];
		      //                                  END
		      //                                  BEGIN
			     //                                   CREATE TABLE [dbo].[Products] (
			     //                                   [Id] INT IDENTITY (1, 1),
			     //                                   [Description] NVARCHAR (150),
			     //                                   [Weight]  DECIMAL,
			     //                                   [Height] DECIMAL,
			     //                                   [Width] DECIMAL,
			     //                                   [Length] DECIMAL);

			     //                                   alter table [Products]
			     //                                   add constraint PK_Products primary key (Id)
		      //                                  END
		      //                                  BEGIN
			     //                                   insert into [Products] ([Description], [Weight], [Height], [Width], [Length])
			     //                                   values 
			     //                                   ('Some description of 1-st Product', 10.5, 15.3, 111, 1111),
			     //                                   ('Some description of 2-d Product', 12.5, 5.65, 222.1, 200),
			     //                                   ('Some description of 3-d Product', 33.3, 65.1, 33333.20, 3),
			     //                                   ('Some description of 4-th Product', 35.7, 62.8, 21, 42),
			     //                                   ('Some description of 5-th Product', 18.7, 128, 44.1, 67.2)
		      //                                  END
        //                                END", Connection);
        //        try
        //        {
        //            Connection.Open();
        //            CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        //            CMD.ExecuteNonQuery();
        //            CMD.Transaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            CMD.Transaction.Rollback();
        //            throw new Exception($"Failed to create Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
        //        }
        //    }
        //}


        public void DeleteStoredProcedure_CreateAndFillProductsTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"IF OBJECT_ID ('CreateAndFillProductsTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillProductsTable];
		                                            END", Connection);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Failed to delete Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
                }
            }
        }
        #endregion

        #region Interface realization
        public void CreateStoredProcedures()
        {
            CreateStoredProcedure_CreateAndFillProductsTable();
        }
        public void DeleteStoredProcedures()
        {
            DeleteStoredProcedure_CreateAndFillProductsTable();
        }
        public void UpdateOrCreateProductsTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"EXEC CreateAndFillProductsTable", Connection);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Failed to execute Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
                }
            }
        }
        public int DeleteProduct(int productId)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"delete from [Products] where Id = @ProductId", Connection);
                CMD.Parameters.AddWithValue("ProductId", productId);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Product, \nReason: {e.Message}");
                }
            }
        }
        //Connected Architecture Method
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"select [Id],
                                                [Description],
                                                [Weight],
                                                [Height],
                                                [Width],
                                                [Length] from Products", Connection);
                SqlDataReader reader;
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    reader = CMD.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = reader.GetFieldValue<int>("Id");
                        p.Description = reader.GetFieldValue<string>("Description");
                        p.Height = reader.GetFieldValue<decimal>("Height");
                        p.Weight = reader.GetFieldValue<decimal>("Weight");
                        p.Width = reader.GetFieldValue<decimal>("Width");
                        p.Length = reader.GetFieldValue<decimal>("Length");
                        products.Add(p);
                    }
                    reader.Close();
                    CMD.Transaction.Commit();
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Failed to get all Products, \nReason: {e.Message}");
                }
            }
            return products;
        }
        public int InsertProduct(Product product)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"insert into [Products] 
                                        ([Description], 
                                        [Weight], 
                                        [Height], 
                                        [Width], 
                                        [Length])
                                        values (@Description, 
                                                @Weight, 
                                                @Height, 
                                                @Width, 
                                                @Length)", Connection);

                CMD.Parameters.AddWithValue("Description", product.Description);
                CMD.Parameters.AddWithValue("Weight", product.Weight);
                CMD.Parameters.AddWithValue("Height", product.Height);
                CMD.Parameters.AddWithValue("Width", product.Width);
                CMD.Parameters.AddWithValue("Length", product.Length);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Was not able to insert Product, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateProduct(Product product)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"update [Products]
                                        set [Description] = @Description,
                                            [Weight] = @Weight,
                                            [Height] = @Height,
                                            [Width] = @Width,
                                            [Length] = @Length
                                        where Id = @Id;", Connection);
                CMD.Parameters.AddWithValue("Id", product.Id);
                CMD.Parameters.AddWithValue("Description", product.Description);
                CMD.Parameters.AddWithValue("Weight", product.Weight);
                CMD.Parameters.AddWithValue("Height", product.Height);
                CMD.Parameters.AddWithValue("Width", product.Width);
                CMD.Parameters.AddWithValue("Length", product.Length);
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = CMD.ExecuteNonQuery();
                    CMD.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Order, \nReason: {e.Message}");
                }
            }
        }
        public void InitializeProductsDB()
        {
            DeleteStoredProcedures();
            CreateStoredProcedures();
            UpdateOrCreateProductsTable();
        }
        #endregion
    }
}
