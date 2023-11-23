CREATE TABLE [dbo].[VisitorInformation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) Not null,
	[IdNumber] nvarchar(50) not null,
	[DoB] nvarchar(15) not null,
	[IdExpiry] nvarchar(15) not null,
	[Nationality] nvarchar(15) not null,
	[IdType] int not null,

)
