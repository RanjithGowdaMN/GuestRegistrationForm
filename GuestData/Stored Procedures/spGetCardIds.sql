CREATE PROCEDURE [dbo].[spGetCardIds]
	
AS
BEGIN
SELECT CardNumber FROM CardId WHERE [Status] =1;
END;
