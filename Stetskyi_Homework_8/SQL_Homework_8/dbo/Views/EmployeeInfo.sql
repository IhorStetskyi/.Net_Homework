CREATE VIEW [dbo].[EmployeeInfo]
AS SELECT [E].[Id] as EmployeeId,
COALESCE([E].[EmployeeName], [P].FirstName + ' ' + [P].LastName) as EmployeeFullName,
[A].[ZipCode]+'_'+[A].[State]+','+[A].[City]+'-'+[A].[Street] as EmployeeFullAddress,
[E].[CompanyName]+'_'+[E].[Position] as EmployeeCompanyInfo,
[E].[Position]
from [Employee] as [E]
left join [Person] as [P] on [P].[Id] = [E].[PersonId]
left join [Address] as [A] on [A].[Id] = [E].[AddressId]