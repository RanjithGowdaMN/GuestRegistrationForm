CREATE PROCEDURE [dbo].[spRetriveCompanyName]

AS
BEGIN
	SELECT CompanyNames As CompanyNames FROM CompanyNameList;
END;