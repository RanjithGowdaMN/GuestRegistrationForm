CREATE PROCEDURE [dbo].[spUpdateCardStatus]
@CardNumber varchar(50)
AS
	
BEGIN
UPDATE CardId SET [Status]=0 WHERE CardNumber=@CardNumber;

END;

