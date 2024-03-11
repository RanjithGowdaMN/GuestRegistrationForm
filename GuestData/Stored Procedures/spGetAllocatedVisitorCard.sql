CREATE PROCEDURE [dbo].[spGetAllocatedVisitorCard]
AS
BEGIN
SELECT CardNumber FROM VisitorCard WHERE [Status] ='5A';
END;