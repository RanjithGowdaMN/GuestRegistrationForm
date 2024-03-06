CREATE PROCEDURE [dbo].[spGetVisitorCard]
AS
BEGIN
SELECT CardNumber FROM VistorCard WHERE [Status] ='A5';
END;