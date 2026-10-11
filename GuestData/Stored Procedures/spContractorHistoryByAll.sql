CREATE PROCEDURE [dbo].[spContractorHistoryByAll]
	@RFU10 nvarchar(50)
AS
BEGIN

SELECT  [Name],[CompanyName],[CardNumber],[DurationStart], [DurationEnd] FROM VisitorInformation  where  RFU10=@RFU10

END
