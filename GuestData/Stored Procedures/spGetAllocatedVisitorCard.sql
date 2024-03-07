CREATE PROCEDURE [dbo].[spGetAllocatedVisitorCard]
AS
BEGIN
SELECT CardNumber FROM VistorCard WHERE [Status] ='5A';
END;
