CREATE PROCEDURE [dbo].[spGetVisitorByIdNumber]
	@IdNumber int = 0
AS
BEGIN

SELECT TOP 1 * FROM VisitorInformation WHERE Id = (SELECT MAX(Id) FROM VisitorInformation WHERE IdNumber = @IdNumber)

END;

RETURN 0;