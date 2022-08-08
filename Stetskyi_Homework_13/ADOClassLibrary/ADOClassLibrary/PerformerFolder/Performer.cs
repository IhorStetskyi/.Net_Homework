using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ADOClassLibrary.PerformerFolder
{
    public class Performer : IPerformer
    {
        private readonly IConnectionProvider connectionProvider;
        public Performer(IConnectionProvider connectionprovider)
        {
            connectionProvider = connectionprovider;
        }
        public void CreateStoredProcedures()
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"CREATE PROCEDURE InitializeDB
                                                    AS
                                                    BEGIN
	                                                    IF OBJECT_ID ('Orders') IS NOT NULL
		                                                    BEGIN
			                                                    DROP TABLE [Orders];
		                                                    END
	                                                    IF OBJECT_ID ('Products') IS NOT NULL
		                                                    BEGIN
			                                                    DROP TABLE [Products];
		                                                    END
		                                                    BEGIN
			                                                    CREATE TABLE [dbo].[Orders] (
			                                                    [Id] INT IDENTITY (1, 1),
			                                                    [Status] NVARCHAR (50),
			                                                    [CreatedDate] DateTime,
			                                                    [UpdatedDate]  DateTime,
			                                                    [ProductId] int);

			                                                    CREATE TABLE [dbo].[Products] (
			                                                    [Id] INT IDENTITY (1, 1),
			                                                    [Description] NVARCHAR (150),
			                                                    [Weight]  DECIMAL,
			                                                    [Height] DECIMAL,
			                                                    [Width] DECIMAL,
			                                                    [Length] DECIMAL);

			                                                    alter table [Products]
			                                                    add constraint PK_Products primary key (Id)

			                                                    alter table [Orders]
			                                                    ADD CONSTRAINT PK_Orders Primary Key (Id),
			                                                    CONSTRAINT CHK_Status CHECK ([Status] in ('NotStarted','Loading', 'InProgress', 'Arrived', 'Unloading', 'Cancelled', 'Done')),
			                                                    CONSTRAINT FK_Orders_Product FOREIGN KEY (ProductId) REFERENCES Products(Id);
		                                                    END
		                                                    BEGIN
			                                                    insert into [Products] ([Description], [Weight], [Height], [Width], [Length])
			                                                    values 
			                                                    ('Some description of 1-st Product', 10.5, 15.3, 111, 1111),
			                                                    ('Some description of 2-d Product', 12.5, 5.65, 222.1, 200),
			                                                    ('Some description of 3-d Product', 33.3, 65.1, 33333.20, 3),
			                                                    ('Some description of 4-th Product', 35.7, 62.8, 21, 42),
			                                                    ('Some description of 5-th Product', 18.7, 128, 44.1, 67.2)


			                                                    insert into [Orders] ([Status],CreatedDate, UpdatedDate,ProductId)
			                                                    values
			                                                    ('NotStarted', '20200101 01:01:01 AM', '20220101 11:11:11 AM', 1),
			                                                    ('Loading', '20200202 02:02:02 AM', '20220101 11:11:11 AM', 1),
			                                                    ('InProgress', '20200303 03:03:03 AM', '20220101 11:11:11 AM', 2),
			                                                    ('Arrived', '20200404 04:04:04 AM', '20220101 11:11:11 AM', 3),
			                                                    ('Unloading', '20200404 04:04:04 AM', '20220101 11:11:11 AM', 3),
			                                                    ('Cancelled', '20200505 05:05:05 AM', '20220101 11:11:11 AM', 4),
			                                                    ('Done', '20200505 05:05:05 AM', '20220101 11:11:11 AM', 4)
		                                                    END
                                                    END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to create Stored Procedure, \nReason: {e.Message}");
                }

            }
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"CREATE PROCEDURE SelectAllOrders
                                                @Status NVARCHAR(50) = NULL,
                                                @ProductId INT = NULL,
                                                @Month INT = NULL,
                                                @Year INT = NULL
                                                AS
                                                BEGIN
	                                                SELECT [Id],
	                                                        [Status],
	                                                        [CreatedDate],
	                                                        [UpdatedDate],
	                                                        [ProductId]
	                                                         FROM [Orders]
	                                                WHERE ProductId = ISNULL(@ProductId,[ProductId])
	                                                                 and [Status] = ISNULL(@Status,[Status])
	                                                                 and MONTH(CreatedDate) = ISNULL(@Month,MONTH([CreatedDate]))
	                                                                 and YEAR(CreatedDate) = ISNULL(@Year,YEAR([CreatedDate]))
                                                END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to create Stored Procedure, \nReason: {e.Message}");
                }

            }
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"CREATE PROCEDURE DeleteOrders
                                                @Status NVARCHAR(50) = NULL,
                                                @ProductId INT = NULL,
                                                @Month INT = NULL,
                                                @Year INT = NULL
                                                AS
                                                BEGIN
	                                                DELETE FROM [Orders]
	                                                WHERE ProductId = ISNULL(@ProductId,[ProductId])
	                                                 and [Status] = ISNULL(@Status,[Status])
	                                                 and MONTH(CreatedDate) = ISNULL(@Month,MONTH([CreatedDate]))
	                                                 and YEAR(CreatedDate) = ISNULL(@Year,YEAR([CreatedDate]))
                                                END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to create Stored Procedure, \nReason: {e.Message}");
                }

            }
        }
        public void DeleteStoredProcedures()
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"IF OBJECT_ID ('InitializeDB') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [InitializeDB];
		                                            END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to delete Stored Procedure, \nReason: {e.Message}");
                }
            }
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"IF OBJECT_ID ('SelectAllOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [SelectAllOrders];
		                                            END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to delete Stored Procedure, \nReason: {e.Message}");
                }
            }
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"IF OBJECT_ID ('DeleteOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [DeleteOrders];
		                                            END", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to delete Stored Procedure, \nReason: {e.Message}");
                }
            }
        }
        public void UpdateDB()
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"EXEC InitializeDB", connection);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to execute Stored Procedure, \nReason: {e.Message}");
                }
            }
        }
        //Disconnected Architecture
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"select
                                                    [Id], 
                                                    [Status], 
                                                    [CreatedDate],
                                                    [UpdatedDate],
                                                    [ProductId] from Orders", connection);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dsData = new DataSet();
                sda.Fill(dsData);

                for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                {
                    Order o = new Order();
                    o.Id = Convert.ToInt32(dsData.Tables[0].Rows[i]["Id"]);
                    o.Status = Convert.ToString(dsData.Tables[0].Rows[i]["Status"]);
                    o.CreatedDate = Convert.ToDateTime(dsData.Tables[0].Rows[i]["CreatedDate"]);
                    o.UpdatedDate = Convert.ToDateTime(dsData.Tables[0].Rows[i]["UpdatedDate"]);
                    o.ProductId = Convert.ToInt32(dsData.Tables[0].Rows[i]["ProductId"]);
                    orders.Add(o);
                }
                return orders;
            }
        }
        //Connected Architecture
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"select [Id],
                                                         [Description],
                                                         [Weight],
                                                         [Height],
                                                         [Width],
                                                         [Length] from Products", connection);
                SqlDataReader reader;
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    reader = cmd.ExecuteReader();

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
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to get all Products, \nReason: {e.Message}");
                }
            }
                return products;
        }
        public List<Order> GetAllOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectAllOrders", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    cmd.Parameters.AddWithValue("@Month", month);
                if (year != -1)
                    cmd.Parameters.AddWithValue("@Year", year);
                if (status != "")
                    cmd.Parameters.AddWithValue("@Status", status);
                if (productId != -1)
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader;
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order o = new Order();
                        o.Id = reader.GetFieldValue<int>("Id");
                        o.Status = reader.GetFieldValue<string>("Status");
                        o.CreatedDate = reader.GetFieldValue<DateTime>("CreatedDate");
                        o.UpdatedDate = reader.GetFieldValue<DateTime>("UpdatedDate");
                        o.ProductId = reader.GetFieldValue<int>("ProductId");
                        orders.Add(o);
                    }
                    reader.Close();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to get all Products, \nReason: {e.Message}");
                }
            }
            return orders;
        }
        public void DeleteOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteOrders", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    cmd.Parameters.AddWithValue("@Month", month);
                if (year != -1)
                    cmd.Parameters.AddWithValue("@Year", year);
                if (status != "")
                    cmd.Parameters.AddWithValue("@Status", status);
                if (productId != -1)
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to delete Orders, \nReason: {e.Message}");
                }
            }
        }
        public int InsertOrder(Order order)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"insert into [Orders]
                                                ([Status],
                                                [CreatedDate], 
                                                [UpdatedDate], 
                                                [ProductId])
                                                values(@Status, 
                                                        @CreatedDate, 
                                                        @UpdatedDate, 
                                                        @ProductId)", connection);

                cmd.Parameters.AddWithValue("Status", order.Status);
                cmd.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                cmd.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                cmd.Parameters.AddWithValue("ProductId", order.ProductId);

                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to insert Order, \nReason: {e.Message}");
                }
               
                               
            }
        }
        public int InsertProduct(Product product)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"insert into [Products] 
                                                    ([Description], 
                                                    [Weight], 
                                                    [Height], 
                                                    [Width], 
                                                    [Length])
                                                    values (@Description, 
                                                            @Weight, 
                                                            @Height, 
                                                            @Width, 
                                                            @Length)", connection);

                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Weight", product.Weight);
                cmd.Parameters.AddWithValue("Height", product.Height);
                cmd.Parameters.AddWithValue("Width", product.Width);
                cmd.Parameters.AddWithValue("Length", product.Length);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to insert Product, \nReason: {e.Message}");
                }


            }
        }
        public int DeleteOrder(int orderId)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"delete from [Orders] where Id = @OrderId", connection);
                cmd.Parameters.AddWithValue("OrderId", orderId);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Order, \nReason: {e.Message}");
                }
            }
        }
        public int DeleteProduct(int productId)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"delete from [Products] where Id = @ProductId", connection);
                cmd.Parameters.AddWithValue("ProductId", productId);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Product, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateOrder(Order order)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"update [Orders]
                                                    set [Status] = @Status, 
                                                        [CreatedDate] = @CreatedDate, 
                                                        [UpdatedDate] = @UpdatedDate, 
                                                        [ProductId] = @ProductId
                                                    where Id = @Id;", connection);
                cmd.Parameters.AddWithValue("Id", order.Id);
                cmd.Parameters.AddWithValue("Status", order.Status);
                cmd.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                cmd.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                cmd.Parameters.AddWithValue("ProductId", order.ProductId);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Order, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateProduct(Product product)
        {
            using (SqlConnection connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"update [Products]
                                                    set [Description] = @Description,
                                                        [Weight] = @Weight,
                                                        [Height] = @Height,
                                                        [Width] = @Width,
                                                        [Length] = @Length
                                                    where Id = @Id;", connection);
                cmd.Parameters.AddWithValue("Id", product.Id);
                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Weight", product.Weight);
                cmd.Parameters.AddWithValue("Height", product.Height);
                cmd.Parameters.AddWithValue("Width", product.Width);
                cmd.Parameters.AddWithValue("Length", product.Length);
                try
                {
                    connection.Open();
                    cmd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Was not able to delete Order, \nReason: {e.Message}");
                }
            }
        }
    }
}
