CREATE PROCEDURE [dbo].[spGetHistoryByName]
	@Name nvarchar(50)
AS
BEGIN

SELECT top 10 [Name],[CompanyName],[PurposeOfVisit],[PersonToBeVisited],[VisitDate] FROM VisitorInformation  where [Name] = @Name AND RFU10='visitor'

END;