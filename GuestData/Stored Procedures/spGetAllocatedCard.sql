CREATE PROCEDURE [dbo].[spGetAllocatedCard]
AS
BEGIN
SELECT CardNumber FROM CardId WHERE [Status] =0;
END;