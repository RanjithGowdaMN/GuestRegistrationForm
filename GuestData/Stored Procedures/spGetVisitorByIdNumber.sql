CREATE PROCEDURE [dbo].[spGetVisitorByIdNumber]
	@IdNumber int = 0
AS
BEGIN
	SELECT TOP 1 *
FROM VisitorInformation WHERE IdNumber = @IdNumber
ORDER BY COALESCE(VisitFromDate, DurationStart) DESC;

END;

RETURN 0;