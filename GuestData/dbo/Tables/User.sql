CREATE TABLE [dbo].[User]
(
	
    [Id] NVARCHAR(128) NOT NULL PRIMARY KEY , 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(200) NOT NULL, 
    [CreateedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
