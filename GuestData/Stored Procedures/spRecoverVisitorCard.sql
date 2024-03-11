CREATE PROCEDURE [dbo].[spRecoverVisitorCard]
@CardNumber varchar(50)
AS
	
BEGIN
UPDATE VisitorCard SET [Status]='A5' WHERE CardNumber=@CardNumber;

END;

