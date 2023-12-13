CREATE PROCEDURE [dbo].[spGetVisitorTitle]
AS
BEGIN
	SELECT Title As Title FROM VisitorTitle;
END;
