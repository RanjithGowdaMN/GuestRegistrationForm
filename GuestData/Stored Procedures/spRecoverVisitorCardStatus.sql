CREATE PROCEDURE [dbo].[spRecoverVisitorCardStatus]
	@CardNumber varchar(50)
AS
	
BEGIN
UPDATE VistorCard SET [Status]='A5' WHERE CardNumber=@CardNumber;

END;
