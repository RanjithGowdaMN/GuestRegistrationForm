CREATE PROCEDURE [dbo].[spVisitorHistoryByAll]
	@RFU10 nvarchar(50)
AS
BEGIN

SELECT  [Name],[CompanyName],[PurposeOfVisit] ,[PersonToBeVisited], [VisitDate] FROM VisitorInformation  where  RFU10=@RFU10

END