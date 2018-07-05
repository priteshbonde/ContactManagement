IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_UpdateContactStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_UpdateContactStatus]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_UpdateContactStatus]
	@ContactID INT
	
	
AS	
	
BEGIN
	
	SET NOCOUNT ON;
	
	DECLARE @Status BIT;

	SELECT @status=Status from [dbo].[Contact] WHERE ContactID=@ContactID
UPDATE [dbo].[Contact]
	SET 
      [Status] =  ~@Status
      WHERE ContactID=@ContactID

		
	END





