﻿CREATE PROCEDURE [dbo].[spcontractorByCard]
@CardNumber nvarchar(50)
AS
BEGIN

SELECT  [Name],[CompanyName],[CardNumber],[DurationStart],[DurationEnd] FROM VisitorInformation  where  CardNumber=@CardNumber and [Status]='A5'

END
