using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADOClassLibrary.InterfaceImplementationFolder
{
    public class ProductPerformer : IProductPerformer
    {
        private readonly IConnectionController connectionProvider;

        public ProductPerformer(IConnectionController connectionprovider)
        {
            connectionProvider = connectionprovider;
        }

        #region Methods to create and delete stored procedures
        public void CreateStoredProcedure_CreateAndFillProductsTable()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"CREATE PROCEDURE CreateAndFillProductsTable
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
                                        END", connectionProvider.Connection);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
                    throw new Exception($"Failed to create Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
                }
            }
        }

        public void DeleteStoredProcedure_CreateAndFillProductsTable()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"IF OBJECT_ID ('CreateAndFillProductsTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillProductsTable];
		                                            END", connectionProvider.Connection);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
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
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"EXEC CreateAndFillProductsTable", connectionProvider.Connection);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
                    throw new Exception($"Failed to execute Stored Procedure CreateAndFillProductsTable, \nReason: {e.Message}");
                }
            }
        }
        public int DeleteProduct(int productId)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"delete from [Products] where Id = @ProductId", connectionProvider.Connection);
                connectionProvider.CMD.Parameters.AddWithValue("ProductId", productId);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    int result = connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                    return result;
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
                    throw new Exception($"Was not able to delete Product, \nReason: {e.Message}");
                }
            }
        }
        //Connected Architecture Method
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"select [Id],
                                                [Description],
                                                [Weight],
                                                [Height],
                                                [Width],
                                                [Length] from Products", connectionProvider.Connection);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    connectionProvider.InitiateReader();

                    while (connectionProvider.Reader.Read())
                    {
                        Product p = new Product();
                        p.Id = connectionProvider.Reader.GetFieldValue<int>("Id");
                        p.Description = connectionProvider.Reader.GetFieldValue<string>("Description");
                        p.Height = connectionProvider.Reader.GetFieldValue<decimal>("Height");
                        p.Weight = connectionProvider.Reader.GetFieldValue<decimal>("Weight");
                        p.Width = connectionProvider.Reader.GetFieldValue<decimal>("Width");
                        p.Length = connectionProvider.Reader.GetFieldValue<decimal>("Length");
                        products.Add(p);
                    }
                    connectionProvider.CloseReader();
                    connectionProvider.CommitTransaction();
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
                    throw new Exception($"Failed to get all Products, \nReason: {e.Message}");
                }
            }
            return products;
        }
        public int InsertProduct(Product product)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"insert into [Products] 
                                        ([Description], 
                                        [Weight], 
                                        [Height], 
                                        [Width], 
                                        [Length])
                                        values (@Description, 
                                                @Weight, 
                                                @Height, 
                                                @Width, 
                                                @Length)", connectionProvider.Connection);

                connectionProvider.AddParameters("Description", product.Description);
                connectionProvider.AddParameters("Weight", product.Weight);
                connectionProvider.AddParameters("Height", product.Height);
                connectionProvider.AddParameters("Width", product.Width);
                connectionProvider.AddParameters("Length", product.Length);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    int result = connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                    return result;
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
                    throw new Exception($"Was not able to insert Product, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateProduct(Product product)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"update [Products]
                                        set [Description] = @Description,
                                            [Weight] = @Weight,
                                            [Height] = @Height,
                                            [Width] = @Width,
                                            [Length] = @Length
                                        where Id = @Id;", connectionProvider.Connection);

                connectionProvider.AddParameters("Id", product.Id);
                connectionProvider.AddParameters("Description", product.Description);
                connectionProvider.AddParameters("Weight", product.Weight);
                connectionProvider.AddParameters("Height", product.Height);
                connectionProvider.AddParameters("Width", product.Width);
                connectionProvider.AddParameters("Length", product.Length);
                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    int result = connectionProvider.CMDExecuteNonQuery();
                    connectionProvider.CommitTransaction();
                    return result;
                }
                catch (Exception e)
                {
                    connectionProvider.RollBackTransaction();
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
