/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].[Person] (Id, FirstName, LastName) VALUES (1, 'Tasleem', 'M');
INSERT INTO [dbo].[Address] (Id, Street, City, State, ZipCode) VALUES (1, '123 Main St', 'Anytown', 'Anystate', '12345');
INSERT INTO [dbo].[Employee] (Id, AddressId, PersonId, CompanyName, Position, EmployeeName) VALUES (1, 1, 1, 'EPAM', 'Developer', 'Tasleem M');
INSERT INTO [dbo].[Company] (Id, Name, AddressId) VALUES (1, 'EPAM', 1);