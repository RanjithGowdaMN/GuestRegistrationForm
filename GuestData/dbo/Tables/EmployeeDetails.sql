CREATE TABLE [dbo].[EmployeeDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(75) NOT NULL,
	[Department] NVARCHAR(75) NOT NULL, 
    [IsHead] BIT NOT NULL,
	 
)
