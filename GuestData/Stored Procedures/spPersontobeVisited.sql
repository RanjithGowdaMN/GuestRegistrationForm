CREATE PROCEDURE [dbo].[spPersontobeVisited]
AS
BEGIN
	SELECT EmployeeNames As EmployeeNames FROM PersonToBeVisited;
END;