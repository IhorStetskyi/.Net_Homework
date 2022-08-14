using DapperLib.DALInterfaces;
using DapperLib.Models;
using System.Collections.Generic;


namespace DapperLib.DALInterfaceImplementation
{
    public class ProductController : IProductController
    {
        public IConnectionController controller;

        public ProductController(IConnectionController controller)
        {
            this.controller = controller;
        }

		public void CreateStoredProcedures()
		{
			string delete1 = @"IF OBJECT_ID ('CreateAndFillProductsTable') IS NOT NULL
		                                            BEGIN
			                                            DROP PROCEDURE [CreateAndFillProductsTable];
		                                            END";
			string create1 = @"CREATE PROCEDURE CreateAndFillProductsTable
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
                                        END";
			controller.ExecuteQuery(delete1);
			controller.ExecuteQuery(create1);
		}

        public void DeletProduct(int productId)
        {
			string sql = @"delete from [Products]
                           where Id = @Id;";
			controller.DeleteData<Product>(sql, new Product { Id = productId });
		}

        public List<Product> GetAllProducts()
        {
            string sql = @"select [Id],
                            [Description],
                            [Weight],
                            [Height],
                            [Width],
                            [Length] from Products";
            return controller.LoadData<Product>(sql);
        }

        public void InsertProduct(Product product)
        {
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
			controller.SaveData<Product>(sql, product);
		}

        public void UpdateOrCreateProductsTable()
		{
			controller.ExecuteStoredProcedure("CreateAndFillProductsTable");
		}

        public void UpdateProduct(Product product)
        {
            string sql = @"update [Products]
                            set [Description] = @Description,
                                [Weight] = @Weight,
                                [Height] = @Height,
                                [Width] = @Width,
                                [Length] = @Length
                                where Id = @Id;";
            controller.UpdateData<Product>(sql, product);
        }
    }
}
