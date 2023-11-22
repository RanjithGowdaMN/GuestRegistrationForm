CREATE PROCEDURE [dbo].[spDepartmentNames]
AS
BEGIN
	SELECT Managers As Managers FROM DepartmentManager;
END;