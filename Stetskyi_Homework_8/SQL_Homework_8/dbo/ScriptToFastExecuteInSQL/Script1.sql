--drop table [Address]
--drop table [Person]
--drop table [Employee]
--drop table [Company]
--drop procedure InsertEmployee
--drop view EmployeeInfo
--drop trigger EmployeeInsertTrigger


--select * from [Address]
--select * from  [Person]
--select * from [Employee]
--select * from  [Company]
--select * from [EmployeeInfo]


--exec InsertEmployee @CompanyName =  'VeryLongCompanyNameSoItShouldBeReducedTo20Symbols', @Street = 'MyStreet1', @FirstName = '   ', @LastName = '    ', @EmployeeName = ' TestEmpName   '