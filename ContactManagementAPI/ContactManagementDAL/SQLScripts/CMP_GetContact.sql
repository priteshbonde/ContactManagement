IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_GetContact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_GetContact]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_GetContact] 	
@ContactID INT
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
	Where ContactID=@ContactID
		
END

GO


