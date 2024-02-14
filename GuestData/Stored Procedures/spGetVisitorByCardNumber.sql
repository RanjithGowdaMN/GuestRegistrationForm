CREATE PROCEDURE [dbo].[spGetVisitorByCardNumber]
@CardNumber nvarchar(15)
AS
BEGIN

SELECT TOP 1 * FROM VisitorInformation WHERE CardNumber = (SELECT MAX(CardNumber) FROM VisitorInformation WHERE CardNumber = @CardNumber)

END;

RETURN 0;
