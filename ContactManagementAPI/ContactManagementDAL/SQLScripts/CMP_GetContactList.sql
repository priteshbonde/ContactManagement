IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_GetContactList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_GetContactList]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_GetContactList] 	

AS
BEGIN
	
	SET NOCOUNT ON;
	
	SELECT 
	ContactID,
	FirstName, 
	LastName, 
	Email, 
	PhoneNumber,
	Status
	FROM 
		Contact
		
END

GO


