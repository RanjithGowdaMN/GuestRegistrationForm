CREATE PROCEDURE [dbo].[spInsertInToCompanyName]
	@CompanyNames nvarchar(75)
AS
BEGIN
	INSERT INTO CompanyNameList(CompanyNames) 
	VALUES (@CompanyNames)
END;