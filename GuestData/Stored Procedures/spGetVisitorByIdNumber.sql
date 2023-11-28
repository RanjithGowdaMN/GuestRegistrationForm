CREATE PROCEDURE [dbo].[spGetVisitorByIdNumber]
	@IdNumber nvarchar(15)
AS
BEGIN

SELECT TOP 1 * FROM VisitorInformation WHERE Id = (SELECT MAX(Id) FROM VisitorInformation WHERE IdNumber = @IdNumber)

END;

RETURN 0;