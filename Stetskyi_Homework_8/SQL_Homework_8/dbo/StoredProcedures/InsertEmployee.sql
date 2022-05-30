CREATE PROCEDURE [dbo].[InsertEmployee]
	@EmployeeName nvarchar(100) = NULL,
	@FirstName nvarchar(50) = NULL,
	@LastName nvarchar(50) = NULL,
	@CompanyName nvarchar(20),
	@Position nvarchar(30) = NULL,
	@Street nvarchar(50),
	@City nvarchar(20) = NULL,
	@State nvarchar(50) = NULL,
	@ZipCode nvarchar(50) = NULL,
	@AddressId int = 1,
	@PersonId int = 1
AS
BEGIN
	declare @trimmedFirstName nvarchar(20) = RTRIM(LTRIM(@FirstName));
	declare @trimmedLastName nvarchar(20) = RTRIM(LTRIM(@LastName));
	declare @trimmedEmployeeName nvarchar(20) = RTRIM(LTRIM(@EmployeeName));
	IF(
	(@FirstName is not null 
	and @LastName is not null 
	and @trimmedFirstName != ''
	and @trimmedLastName != '') 
	OR 
	(@EmployeeName is not null 
	and @trimmedEmployeeName != '')
	)
		BEGIN
			INSERT INTO [Person]([FirstName], [LastName])
			VALUES (COALESCE(@FirstName, 'Temp_FirstName'), COALESCE(@LastName, 'Temp_LastName'));

			INSERT INTO [Address]([Street], [City], [State], [ZipCode])
			VALUES (@Street, @City, @State, @ZipCode);

			INSERT INTO [Employee]([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
			VALUES (@AddressId, @PersonId, left(@CompanyName, 20), @Position, @EmployeeName);
			RETURN 1
		END
	ELSE
	BEGIN
		RAISERROR('The value for @FirstName and @LastName or @EmployeeName should be populated', 15, 1)
	END
END