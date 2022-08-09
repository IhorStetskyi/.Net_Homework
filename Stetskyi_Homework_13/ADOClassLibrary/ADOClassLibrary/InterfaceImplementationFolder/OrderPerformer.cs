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
        private readonly IConnectionController connectionProvider;
        public OrderPerformer(IConnectionController connectionprovider)
        {
            connectionProvider = connectionprovider;
        }

        #region Methods to create and delete stored procedures
        public void CreateStoredProcedure_CreateAndFillOrdersTable()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"CREATE PROCEDURE CreateAndFillOrdersTable
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
                    throw new Exception($"Failed to create Stored Procedure CreateAndFillOrdersTable, \nReason: {e.Message}");
                }
            }
        }
        public void CreateStoredProcedure_SelectAllOrders()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"CREATE PROCEDURE SelectAllOrders
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
                    throw new Exception($"Failed to create Stored Procedure SelectAllOrders, \nReason: {e.Message}");
                }

            }
        }
        public void CreateStoredProcedure_DeleteOrders()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"CREATE PROCEDURE DeleteOrders
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
                    throw new Exception($"Failed to create Stored Procedure DeleteOrders, \nReason: {e.Message}");
                }

            }
        }
        public void DeleteStoredProcedure_CreateAndFillOrdersTable()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"IF OBJECT_ID ('CreateAndFillOrdersTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillOrdersTable];
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
                    throw new Exception($"Failed to delete Stored Procedure CreateAndFillOrdersTable, \nReason: {e.Message}");
                }
            }
        }
        public void DeleteStoredProcedure_SelectAllOrders()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"IF OBJECT_ID ('SelectAllOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [SelectAllOrders];
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
                    throw new Exception($"Failed to delete Stored Procedure SelectAllOrders, \nReason: {e.Message}");
                }
            }
        }
        public void DeleteStoredProcedure_DeleteOrders()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"IF OBJECT_ID ('DeleteOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [DeleteOrders];
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
                    throw new Exception($"Failed to delete Stored Procedure DeleteOrders, \nReason: {e.Message}");
                }
            }
        }
        #endregion


        #region Interface realization
        public void UpdateOrCreateOrdersTable()
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"EXEC CreateAndFillOrdersTable", connectionProvider.Connection);
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
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"delete from [Orders] where Id = @OrderId", connectionProvider.Connection);
                connectionProvider.CMD.Parameters.AddWithValue("OrderId", orderId);
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
        public void DeleteOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand("DeleteOrders", connectionProvider.Connection);
                connectionProvider.CMD.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    connectionProvider.AddParameters("@Month", month);
                if (year != -1)
                    connectionProvider.AddParameters("@Year", year);
                if (status != "")
                    connectionProvider.AddParameters("@Status", status);
                if (productId != -1)
                    connectionProvider.AddParameters("@ProductId", productId);

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
                    throw new Exception($"Failed to delete Orders, \nReason: {e.Message}");
                }
            }
        }
        public List<Order> GetAllOrders(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            List<Order> orders = new List<Order>();
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand("SelectAllOrders", connectionProvider.Connection);
                connectionProvider.CMD.CommandType = CommandType.StoredProcedure;
                if (month != -1)
                    connectionProvider.AddParameters("@Month", month);
                if (year != -1)
                    connectionProvider.AddParameters("@Year", year);
                if (status != "")
                    connectionProvider.AddParameters("@Status", status);
                if (productId != -1)
                    connectionProvider.AddParameters("@ProductId", productId);

                try
                {
                    connectionProvider.OpenConnection();
                    connectionProvider.BeginTransaction();
                    connectionProvider.InitiateReader();

                    while (connectionProvider.Reader.Read())
                    {
                        Order o = new Order();
                        o.Id = connectionProvider.Reader.GetFieldValue<int>("Id");
                        o.Status = connectionProvider.Reader.GetFieldValue<string>("Status");
                        o.CreatedDate = connectionProvider.Reader.GetFieldValue<DateTime>("CreatedDate");
                        o.UpdatedDate = connectionProvider.Reader.GetFieldValue<DateTime>("UpdatedDate");
                        o.ProductId = connectionProvider.Reader.GetFieldValue<int>("ProductId");
                        orders.Add(o);
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
            return orders;
        }
        //Disconnected Architecture
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"select
                                        [Id], 
                                        [Status], 
                                        [CreatedDate],
                                        [UpdatedDate],
                                        [ProductId] from Orders", connectionProvider.Connection);

                connectionProvider.InitializeDataAdapter();
                connectionProvider.InitializeDataSet();
                connectionProvider.FillDataSet();

                for (int i = 0; i < connectionProvider.DataSetValue.Tables[0].Rows.Count; i++)
                {
                    Order o = new Order();
                    o.Id = Convert.ToInt32(connectionProvider.DataSetValue.Tables[0].Rows[i]["Id"]);
                    o.Status = Convert.ToString(connectionProvider.DataSetValue.Tables[0].Rows[i]["Status"]);
                    o.CreatedDate = Convert.ToDateTime(connectionProvider.DataSetValue.Tables[0].Rows[i]["CreatedDate"]);
                    o.UpdatedDate = Convert.ToDateTime(connectionProvider.DataSetValue.Tables[0].Rows[i]["UpdatedDate"]);
                    o.ProductId = Convert.ToInt32(connectionProvider.DataSetValue.Tables[0].Rows[i]["ProductId"]);
                    orders.Add(o);
                }
                return orders;
            }
        }
        public int InsertOrder(Order order)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"insert into [Orders]
                                        ([Status],
                                        [CreatedDate], 
                                        [UpdatedDate], 
                                        [ProductId])
                                        values(@Status, 
                                                @CreatedDate, 
                                                @UpdatedDate, 
                                                @ProductId)", connectionProvider.Connection);

                connectionProvider.AddParameters("Status", order.Status);
                connectionProvider.AddParameters("CreatedDate", order.CreatedDate);
                connectionProvider.AddParameters("UpdatedDate", order.UpdatedDate);
                connectionProvider.AddParameters("ProductId", order.ProductId);

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
                    throw new Exception($"Was not able to insert Order, \nReason: {e.Message}");
                }
            }
        }
        public int UpdateOrder(Order order)
        {
            using (connectionProvider.Connection = connectionProvider.GetConnection())
            {
                connectionProvider.CMD = new SqlCommand(@"update [Orders]
                                        set [Status] = @Status, 
                                            [CreatedDate] = @CreatedDate, 
                                            [UpdatedDate] = @UpdatedDate, 
                                            [ProductId] = @ProductId
                                        where Id = @Id;", connectionProvider.Connection);
                connectionProvider.AddParameters("Id", order.Id);
                connectionProvider.AddParameters("Status", order.Status);
                connectionProvider.AddParameters("CreatedDate", order.CreatedDate);
                connectionProvider.AddParameters("UpdatedDate", order.UpdatedDate);
                connectionProvider.AddParameters("ProductId", order.ProductId);
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
        public void InitializeOrdersDB()
        {
            DeleteStoredProcedures();
            CreateStoredProcedures();
            UpdateOrCreateOrdersTable();
        }
        #endregion


    }
}
