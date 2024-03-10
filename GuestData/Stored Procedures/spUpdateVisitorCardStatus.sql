CREATE PROCEDURE [dbo].[spUpdateVisitorCardStatus]
@CardNumber varchar(50)
AS
	
BEGIN
UPDATE VisitorCard SET [Status]='5A' WHERE CardNumber=@CardNumber;

END;