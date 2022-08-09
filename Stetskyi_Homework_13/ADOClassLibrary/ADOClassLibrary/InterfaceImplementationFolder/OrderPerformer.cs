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
    public class OrderPerformer : IOrderPerformer
    {
        private readonly IConnectionProvider connectionProvider;
        public SqlConnection Connection { get; set; }
        public SqlCommand CMD { get; set; }
        public SqlDataAdapter SQLDataAdapter { get; set; }
        public DataSet DataSetValue { get; set; }
        public OrderPerformer(IConnectionProvider connectionprovider)
        {
            connectionProvider = connectionprovider;
        }

        #region Methods to create and delete stored procedures
        public void CreateStoredProcedure_CreateAndFillOrdersTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"CREATE PROCEDURE CreateAndFillOrdersTable
                                        AS
                                        BEGIN
	                                        IF OBJECT_ID ('Orders') IS NOT NULL
		                                        BEGIN
			                                        DROP TABLE [Orders];
		                                        END
		                                        BEGIN
			                                        CREATE TABLE [dbo].[Orders] (
			                                        [Id] INT IDENTITY (1, 1),
			                                        [Status] NVARCHAR (50),
			                                        [CreatedDate] DateTime,
			                                        [UpdatedDate]  DateTime,
			                                        [ProductId] int);
			
			                                        alter table [Orders]
			                                        ADD CONSTRAINT PK_Orders Primary Key (Id),
			                                        CONSTRAINT CHK_Status CHECK ([Status] in ('NotStarted','Loading', 'InProgress', 'Arrived', 'Unloading', 'Cancelled', 'Done')),
			                                        CONSTRAINT FK_Orders_Product FOREIGN KEY (ProductId) REFERENCES Products(Id);
		                                        END
		                                        BEGIN
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
                    throw new Exception($"Failed to create Stored Procedure CreateAndFillOrdersTable, \nReason: {e.Message}");
                }
            }
        }
        public void CreateStoredProcedure_SelectAllOrders()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"CREATE PROCEDURE SelectAllOrders
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
                    throw new Exception($"Failed to create Stored Procedure SelectAllOrders, \nReason: {e.Message}");
                }

            }
        }
        public void CreateStoredProcedure_DeleteOrders()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"CREATE PROCEDURE DeleteOrders
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
                    throw new Exception($"Failed to create Stored Procedure DeleteOrders, \nReason: {e.Message}");
                }

            }
        }
        public void DeleteStoredProcedure_CreateAndFillOrdersTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"IF OBJECT_ID ('CreateAndFillOrdersTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillOrdersTable];
		                                            END", Connection);
                try
                {
                    Connection.Open();
                    cmd.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception($"Failed to delete Stored Procedure CreateAndFillOrdersTable, \nReason: {e.Message}");
                }
            }
        }
        public void DeleteStoredProcedure_SelectAllOrders()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"IF OBJECT_ID ('SelectAllOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [SelectAllOrders];
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
                    throw new Exception($"Failed to delete Stored Procedure SelectAllOrders, \nReason: {e.Message}");
                }
            }
        }
        public void DeleteStoredProcedure_DeleteOrders()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"IF OBJECT_ID ('DeleteOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [DeleteOrders];
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
                    throw new Exception($"Failed to delete Stored Procedure DeleteOrders, \nReason: {e.Message}");
                }
            }
        }
        #endregion


        #region Interface realization
        public void UpdateOrCreateOrdersTable()
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"EXEC CreateAndFillOrdersTable", Connection);
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
                    throw new Exception($"Failed to execute Stored Procedure CreateAndFillOrdersTable, \nReason: {e.Message}");
                }
            }
        }
        public void CreateStoredProcedures()
        {
            CreateStoredProcedure_CreateAndFillOrdersTable();
            CreateStoredProcedure_SelectAllOrders();
            CreateStoredProcedure_DeleteOrders();
        }
        public void DeleteStoredProcedures()
        {
            DeleteStoredProcedure_CreateAndFillOrdersTable();
            DeleteStoredProcedure_SelectAllOrders();
            DeleteStoredProcedure_DeleteOrders();
        }
        public int DeleteOrder(int orderId)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"delete from [Orders] where Id = @OrderId", Connection);
                CMD.Parameters.AddWithValue("OrderId", orderId);
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
        public void DeleteOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand("DeleteOrders", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    CMD.Parameters.AddWithValue("@Month", month);
                if (year != -1)
                    CMD.Parameters.AddWithValue("@Year", year);
                if (status != "")
                    CMD.Parameters.AddWithValue("@Status", status);
                if (productId != -1)
                    CMD.Parameters.AddWithValue("@ProductId", productId);

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
                    throw new Exception($"Failed to delete Orders, \nReason: {e.Message}");
                }
            }
        }
        public List<Order> GetAllOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            List<Order> orders = new List<Order>();
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand("SelectAllOrders", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    CMD.Parameters.AddWithValue("@Month", month);
                if (year != -1)
                    CMD.Parameters.AddWithValue("@Year", year);
                if (status != "")
                    CMD.Parameters.AddWithValue("@Status", status);
                if (productId != -1)
                    CMD.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader;
                try
                {
                    Connection.Open();
                    CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    reader = CMD.ExecuteReader();

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
                    CMD.Transaction.Commit();
                }
                catch (Exception e)
                {
                    CMD.Transaction.Rollback();
                    throw new Exception($"Failed to get all Products, \nReason: {e.Message}");
                }
            }
            return orders;
        }
        //Disconnected Architecture
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"select
                                        [Id], 
                                        [Status], 
                                        [CreatedDate],
                                        [UpdatedDate],
                                        [ProductId] from Orders", Connection);

                SQLDataAdapter = new SqlDataAdapter(CMD);
                DataSetValue = new DataSet();
                SQLDataAdapter.Fill(DataSetValue);

                for (int i = 0; i < DataSetValue.Tables[0].Rows.Count; i++)
                {
                    Order o = new Order();
                    o.Id = Convert.ToInt32(DataSetValue.Tables[0].Rows[i]["Id"]);
                    o.Status = Convert.ToString(DataSetValue.Tables[0].Rows[i]["Status"]);
                    o.CreatedDate = Convert.ToDateTime(DataSetValue.Tables[0].Rows[i]["CreatedDate"]);
                    o.UpdatedDate = Convert.ToDateTime(DataSetValue.Tables[0].Rows[i]["UpdatedDate"]);
                    o.ProductId = Convert.ToInt32(DataSetValue.Tables[0].Rows[i]["ProductId"]);
                    orders.Add(o);
                }
                return orders;
            }
        }
        public int InsertOrder(Order order)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"insert into [Orders]
                                        ([Status],
                                        [CreatedDate], 
                                        [UpdatedDate], 
                                        [ProductId])
                                        values(@Status, 
                                                @CreatedDate, 
                                                @UpdatedDate, 
                                                @ProductId)", Connection);

                CMD.Parameters.AddWithValue("Status", order.Status);
                CMD.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                CMD.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                CMD.Parameters.AddWithValue("ProductId", order.ProductId);

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
                    throw new Exception($"Was not able to insert Order, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateOrder(Order order)
        {
            using (Connection = connectionProvider.GetConnection())
            {
                CMD = new SqlCommand(@"update [Orders]
                                        set [Status] = @Status, 
                                            [CreatedDate] = @CreatedDate, 
                                            [UpdatedDate] = @UpdatedDate, 
                                            [ProductId] = @ProductId
                                        where Id = @Id;", Connection);
                CMD.Parameters.AddWithValue("Id", order.Id);
                CMD.Parameters.AddWithValue("Status", order.Status);
                CMD.Parameters.AddWithValue("CreatedDate", order.CreatedDate);
                CMD.Parameters.AddWithValue("UpdatedDate", order.UpdatedDate);
                CMD.Parameters.AddWithValue("ProductId", order.ProductId);
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
        public void InitializeOrdersDB()
        {
            DeleteStoredProcedures();
            CreateStoredProcedures();
            UpdateOrCreateOrdersTable();
        }
        #endregion


    }
}
