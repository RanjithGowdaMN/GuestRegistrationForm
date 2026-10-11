IF DB_ID(N'GuestData') IS NULL CREATE DATABASE [GuestData];
GO
USE [GuestData];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
GO
IF OBJECT_ID(N'dbo.ProductionManagers', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[ProductionManagers]
(
	[ProductionManager] NVARCHAR(75) NOT NULL PRIMARY KEY
)

END
GO
IF OBJECT_ID(N'dbo.AreaToBeVisited', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[AreaToBeVisited]
(
	[Area] NVARCHAR(75) NOT NULL PRIMARY KEY
)

END
GO
IF OBJECT_ID(N'dbo.CompanyNameList', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[CompanyNameList]
(
	[CompanyNames] nvarchar(75) NOT NULL PRIMARY KEY
)

END
GO
IF OBJECT_ID(N'dbo.DepartmentManager', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[DepartmentManager]
(
	[Managers] nvarchar(75) NOT NULL PRIMARY KEY, 
    [Department] NCHAR(50) NOT NULL
)

END
GO
IF OBJECT_ID(N'dbo.DepartmentNames', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[DepartmentNames]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Departments] nvarchar(75) NOT NULL
)

END
GO
IF OBJECT_ID(N'dbo.EmployeeDetails', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[EmployeeDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(75) NOT NULL,
	[Department] NVARCHAR(75) NOT NULL, 
    [IsHead] BIT NOT NULL,
	 
)

END
GO
IF OBJECT_ID(N'dbo.PersonToBeVisited', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[PersonToBeVisited]
(
    [Id] INT NOT NULL IDENTITY
    PRIMARY KEY ([Id]),
	[EmployeeNames] NVARCHAR(75) NOT NULL 
    
)

END
GO
IF OBJECT_ID(N'dbo.SecurityController', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[SecurityController]
(
	[Name] nvarchar(50) NOT NULL PRIMARY KEY
)

END
GO
IF OBJECT_ID(N'dbo.User', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[User]
(
	
    [Id] NVARCHAR(128) NOT NULL PRIMARY KEY , 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(200) NOT NULL, 
    [CreateedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)

END
GO
IF OBJECT_ID(N'dbo.VisitorInformation', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[VisitorInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IdNumber] [nvarchar](15) NOT NULL,
	[Dob] [nvarchar](15) NULL,
	[IdExpiry] [nvarchar](15) NULL,
	[IdType] [int] NOT NULL,
	[IdFrontSide] NVARCHAR(MAX) NOT NULL,
	[IdBackSide] NVARCHAR(MAX) NULL,
	[Photo] NVARCHAR(MAX) NULL,
	[Title] [nvarchar](15) NULL,
	[CompanyName] [nvarchar](50) NULL,
	[PurposeOfVisit] [nvarchar](50) NULL,
	[City] [nvarchar](25) NULL,
	[Address] [nvarchar](25) NULL,
	[Zip] [nvarchar](25) NULL,
	[State] [nvarchar](25) NULL,
	[CellPhone] [nvarchar](25) NULL,
	[Email] [nvarchar](25) NULL,
	[SocialSecurityNumber] [nvarchar](25) NULL,
	[HomePhoneNo] [nvarchar](25) NULL,
	[PassportNumber] [nvarchar](25) NULL,
	[PassportIssuePlace] [nvarchar](50) NULL,
	[PassportIssuedOn] [nvarchar](25) NULL,
	[PassportValidity] [nvarchar](25) NULL,
	[EmergencyContact] [nvarchar](25) NULL,
	[AliasName] [nvarchar](50) NULL,
	[Convicted] [bit] NULL,
	[Previous7YrResidency] [nvarchar](150) NULL,
	[PersonToBeVisited] [nvarchar](150) NULL,
	[AreaToBeVisited] [nvarchar](50) NULL,
	[VisitDate] [nvarchar](15) NULL,
	[VisitTime] [nvarchar](15) NULL,
	[DurationStart] [nvarchar](15) NULL,
	[DurationEnd] [nvarchar](15) NULL,
	[Duration] [nvarchar](15) NULL,
	[VisitFromDate] [nvarchar](15) NULL,
	[VisitToDuration] [nvarchar](15) NULL,
	[StartTime] [nvarchar](15) NULL,
	[EndTime] [nvarchar](15) NULL,
	[VisitDuration] [nvarchar](15) NULL,
	[DepartmentManager] [nvarchar](50) NULL,
	[ProductionManager] [nvarchar](50) NULL,
	[SecurityController] [nvarchar](50) NULL,
	[RFU1] [nvarchar](100) NULL,
	[RFU2] [nvarchar](100) NULL,
	[RFU3] [nvarchar](100) NULL,
	[RFU4] [nvarchar](100) NULL,
	[RFU5] [nvarchar](100) NULL,
	[RFU6] [nvarchar](100) NULL,
	[RFU7] [nvarchar](100) NULL,
	[RFU8] [nvarchar](100) NULL,
	[RFU9] [nvarchar](100) NULL,
	[RFU10] [nvarchar](100) NULL,
)

END
GO
IF OBJECT_ID(N'dbo.VisitorTitle', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[VisitorTitle]
(
	[Title] nvarchar(50) NOT NULL PRIMARY KEY
)

END
GO
IF OBJECT_ID(N'dbo.VisitorVisitPurpose', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[VisitorVisitPurpose]
(
	[Purpose] NVARCHAR(75) NOT NULL PRIMARY KEY
)

END
GO
CREATE OR ALTER PROCEDURE [dbo].[spAreatobeVisited]
AS
BEGIN
	SELECT Area As Area FROM AreaToBeVisited;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spDepartmentManager]
AS
BEGIN
	SELECT Managers As Managers FROM DepartmentManager;
END;

GO
CREATE OR ALTER PROCEDURE [dbo].[spDepartmentNames]
AS
BEGIN
	SELECT Managers As Managers FROM DepartmentManager;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spGetVisitorByIdNumber]
	@IdNumber nvarchar(15)
AS
BEGIN

SELECT TOP 1 * FROM VisitorInformation WHERE Id = (SELECT MAX(Id) FROM VisitorInformation WHERE IdNumber = @IdNumber)

END;

RETURN 0;
GO
CREATE OR ALTER PROCEDURE [dbo].[spGetVisitorTitle]
AS
BEGIN
	SELECT Title As Title FROM VisitorTitle;
END;

GO
CREATE OR ALTER PROCEDURE [dbo].[spInsertInToCompanyName]
	@CompanyNames nvarchar(75)
AS
BEGIN
	INSERT INTO CompanyNameList(CompanyNames) 
	VALUES (@CompanyNames)
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spInsertVisitorInformation]

@Name [nvarchar](50),
@IdNumber [nvarchar](15),
@Dob [nvarchar](15),
@IdExpiry [nvarchar](15),
@IdType [int],
@IdFrontSide [varchar](max),
@IdBackSide [varchar](max),
@Photo [varchar](max),
@Title [nvarchar](15),
@CompanyName [nvarchar](50),
@PurposeOfVisit [nvarchar](50),
@City [nvarchar](25),
@Address [nvarchar](25),
@Zip [nvarchar](25),
@State [nvarchar](25),
@CellPhone [nvarchar](25),
@Email [nvarchar](25),
@SocialSecurityNumber [nvarchar](25),
@HomePhoneNo [nvarchar](25),
@PassportNumber [nvarchar](25),
@PassportIssuePlace [nvarchar](50),
@PassportIssuedOn [nvarchar](25),
@PassportValidity [nvarchar](25),
@EmergencyContact [nvarchar](25),
@AliasName [nvarchar](50),
@Convicted [bit],
@Previous7YrResidency [nvarchar](150),
@PersonToBeVisited [nvarchar](150),
@AreaToBeVisited [nvarchar](50),
@VisitDate [nvarchar](15),
@VisitTime [nvarchar](15),
@DurationStart [nvarchar](15),
@DurationEnd [nvarchar](15),
@Duration [nvarchar](15),
@VisitFromDate [nvarchar](15),
@VisitToDuration [nvarchar](15),
@StartTime [nvarchar](15),
@EndTime [nvarchar](15),
@VisitDuration [nvarchar](15),
@DepartmentManager [nvarchar](50),
@ProductionManager [nvarchar](50),
@SecurityController [nvarchar](50),
@RFU1 [nvarchar](100),
@RFU2 [nvarchar](100),
@RFU3 [nvarchar](100),
@RFU4 [nvarchar](100),
@RFU5 [nvarchar](100),
@RFU6 [nvarchar](100),
@RFU7 [nvarchar](100),
@RFU8 [nvarchar](100),
@RFU9 [nvarchar](100),
@RFU10 [nvarchar](100)

AS 
BEGIN 

INSERT INTO Visitorinformation(Name ,IdNumber ,Dob ,IdExpiry ,IdType ,IdFrontSide ,IdBackSide ,Photo ,Title ,CompanyName ,PurposeOfVisit ,City ,Address ,Zip ,State ,CellPhone ,Email ,SocialSecurityNumber ,HomePhoneNo ,PassportNumber ,PassportIssuePlace ,PassportIssuedOn ,PassportValidity ,EmergencyContact ,AliasName ,Convicted ,Previous7YrResidency ,PersonToBeVisited ,AreaToBeVisited ,VisitDate ,VisitTime ,DurationStart ,DurationEnd ,Duration ,VisitFromDate ,VisitToDuration ,StartTime ,EndTime ,VisitDuration ,DepartmentManager ,ProductionManager ,SecurityController ,RFU1 ,RFU2 ,RFU3 ,RFU4 ,RFU5 ,RFU6 ,RFU7 ,RFU8 ,RFU9 ,RFU10)

VALUES(@Name, @IdNumber, @Dob, @IdExpiry, @IdType, @IdFrontSide, @IdBackSide, @Photo, @Title, @CompanyName, @PurposeOfVisit, @City, @Address, @Zip, @State, @CellPhone, @Email, @SocialSecurityNumber, @HomePhoneNo, @PassportNumber, @PassportIssuePlace, @PassportIssuedOn, @PassportValidity, @EmergencyContact, @AliasName, @Convicted, @Previous7YrResidency, @PersonToBeVisited, @AreaToBeVisited, @VisitDate, @VisitTime, @DurationStart, @DurationEnd, @Duration, @VisitFromDate, @VisitToDuration, @StartTime, @EndTime, @VisitDuration, @DepartmentManager, @ProductionManager, @SecurityController, @RFU1, @RFU2, @RFU3, @RFU4, @RFU5, @RFU6, @RFU7, @RFU8, @RFU9, @RFU10);
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spPersontobeVisited]
AS
BEGIN
	SELECT EmployeeNames As EmployeeNames FROM PersonToBeVisited;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spProductionManagers]
AS
BEGIN
	SELECT ProductionManager As ProductionManager FROM ProductionManagers;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spRetriveCompanyName]

AS
BEGIN
	SELECT CompanyNames As CompanyNames FROM CompanyNameList;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spSecurityController]
AS
BEGIN
	SELECT Name As Name FROM SecurityController;
END;
GO
CREATE OR ALTER PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
BEGIN
	set nocount on;

	SELECT Id, Firstname, LastName, EmailAddress, CreateedDate
	from [dbo].[User]
	where Id = @Id
END
RETURN 0

GO
CREATE OR ALTER PROCEDURE [dbo].[spVisitorVisitPurpose]
AS
BEGIN
	SELECT Purpose As Purpose FROM VisitorVisitPurpose;
END;
GO
COMMIT TRANSACTION;
GO