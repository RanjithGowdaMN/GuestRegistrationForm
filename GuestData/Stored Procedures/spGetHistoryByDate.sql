CREATE PROCEDURE [dbo].[spGetHistoryByDate]
	@VisitDate nvarchar(15)
AS
BEGIN

SELECT top 10 [Name],[CompanyName],[PurposeOfVisit],[PersonToBeVisited],[VisitDate] FROM VisitorInformation  where VisitDate = @VisitDate AND RFU10='visitor'

END;
