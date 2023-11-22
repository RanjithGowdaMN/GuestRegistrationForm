CREATE PROCEDURE [dbo].[spProductionManagers]
AS
BEGIN
	SELECT ProductionManager As ProductionManager FROM ProductionManagers;
END;