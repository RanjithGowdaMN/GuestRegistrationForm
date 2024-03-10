CREATE PROCEDURE [dbo].[spGetVisitorCard]
AS
BEGIN

SELECT CardNumber FROM VisitorCard WHERE [Status] ='A5';

END;