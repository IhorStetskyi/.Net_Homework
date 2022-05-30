CREATE TRIGGER [EmployeeInsertTrigger]
	ON [dbo].[Employee]
		AFTER INSERT
		AS
		SET NOCOUNT ON
		BEGIN
			INSERT INTO [Company]([Name], [AddressId])
			select [CompanyName], [AddressId] from inserted
			order by [Id] ASC
		END