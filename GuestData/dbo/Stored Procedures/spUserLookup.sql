CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
BEGIN
	set nocount on;

	SELECT Id, Firstname, LastName, EmailAddress, CreateedDate
	from [dbo].[User]
	where Id = @Id
END
RETURN 0
