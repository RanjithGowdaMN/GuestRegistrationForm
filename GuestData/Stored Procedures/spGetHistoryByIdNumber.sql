CREATE PROCEDURE [dbo].[spGetHistoryByIdNumber]
	@IdNumber nvarchar(15)
AS
BEGIN

SELECT top 10 [Name],[CompanyName],[PurposeOfVisit],[PersonToBeVisited],[VisitDate] FROM VisitorInformation  where IdNumber = @IdNumber AND RFU10='visitor'

END;
