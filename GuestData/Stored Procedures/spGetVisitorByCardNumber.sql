CREATE PROCEDURE [dbo].[spGetVisitorByCardNumber]
@CardNumber nvarchar(15)
AS
BEGIN

SELECT  * FROM VisitorInformation WHERE CardNumber = @CardNumber and  [Status]='A5'

END;
