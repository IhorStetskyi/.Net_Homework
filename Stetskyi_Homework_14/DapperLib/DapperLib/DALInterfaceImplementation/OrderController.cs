using DapperLib.DALInterfaces;
using DapperLib.Models;
using System.Collections.Generic;
using Dapper;

namespace DapperLib.DALInterfaceImplementation
{
    public class OrderController : IOrderController
    {
        public IConnectionController controller;

        public OrderController(IConnectionController controller)
        {
            this.controller = controller;
        }
        public List<Order> GetAllOrders()
        {
            string sql = @"select
                            [Id],
                            [Status],
                            [CreatedDate],
                            [UpdatedDate],
                            [ProductId] from Orders";
            return controller.LoadData<Order>(sql);
        }
        public List<Order> GetAllOrdersFiltrated(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            List<Order> orders = new List<Order>();
            string sql = @"SelectAllOrders";

            DynamicParameters dynamicParameters = new DynamicParameters();
            if (month != -1)
                dynamicParameters.Add("@Month", month);
            if (year != -1)
                dynamicParameters.Add("@Year", year);
            if (status != "")
                dynamicParameters.Add("@Status", status);
            if (productId != -1)
                dynamicParameters.Add("@ProductId", productId);

            return controller.LoadDataFiltred<Order>(sql, dynamicParameters);
        }
        public void DeleteOrdersFiltrated(int month = -1, string status = "", int year = -1, int productId = -1)
        {
            string sql = @"DeleteOrders";
            DynamicParameters dynamicParameters = new DynamicParameters();
            if (month != -1)
                dynamicParameters.Add("@Month", month);
            if (year != -1)
                dynamicParameters.Add("@Year", year);
            if (status != "")
                dynamicParameters.Add("@Status", status);
            if (productId != -1)
                dynamicParameters.Add("@ProductId", productId);

            controller.DeleteDataFiltred(sql, dynamicParameters);
        }
        public void InsertOrder(Order order)
        {
            string sql = @"insert into [Orders]
                                        ([Status],
                                        [CreatedDate], 
                                        [UpdatedDate], 
                                        [ProductId])
                                        values(@Status, 
                                                @CreatedDate, 
                                                @UpdatedDate, 
                                                @ProductId)";
            controller.SaveData<Order>(sql, order);
        }
        public void UpdateOrder(Order order)
        {
            string sql = @"update [Orders]
                            set [Status] = @Status, 
                                [CreatedDate] = @CreatedDate, 
                                [UpdatedDate] = @UpdatedDate, 
                                [ProductId] = @ProductId
                                where Id = @Id;";
            controller.UpdateData<Order>(sql, order);
        }
        public void DeleteOrder(int orderId)
        {
            string sql = @"delete from [Orders]
                           where Id = @Id;";
            controller.DeleteData<Order>(sql, new Order {Id = orderId });
        }

        public void CreateStoredProcedures()
        {
            string delete1 = @"IF OBJECT_ID ('CreateAndFillOrdersTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillOrdersTable];
		                                            END";
            string delete2 = @"IF OBJECT_ID ('SelectAllOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [SelectAllOrders];
		                                            END";
            string delete3 = @"IF OBJECT_ID ('DeleteOrders') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [DeleteOrders];
		                                            END";


            string create1 = @"CREATE PROCEDURE CreateAndFillOrdersTable
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
                                        END";
            string create2 = @"CREATE PROCEDURE SelectAllOrders
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
                                        END";

            string create3 = @"CREATE PROCEDURE DeleteOrders
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
                                                END";
            controller.ExecuteQuery(delete1);
            controller.ExecuteQuery(delete2);
            controller.ExecuteQuery(delete3);
            controller.ExecuteQuery(create1);
            controller.ExecuteQuery(create2);
            controller.ExecuteQuery(create3);
        }
        public void UpdateOrCreateOrdersTable()
        {
            controller.ExecuteStoredProcedure("CreateAndFillOrdersTable");
        }



    }
}
