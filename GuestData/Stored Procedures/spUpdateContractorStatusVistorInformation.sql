CREATE PROCEDURE [dbo].[spUpdateContractorStatusVistorInformation]
@CardNumber varchar(50)
AS
	
BEGIN
UPDATE VisitorInformation SET [Status]='5A' WHERE CardNumber=@CardNumber;

END;
