CREATE PROCEDURE [dbo].[spRecoverCardStatus]
@CardNumber varchar(50)
AS
	
BEGIN
UPDATE CardId SET [Status]=1 WHERE CardNumber=@CardNumber;

END;

