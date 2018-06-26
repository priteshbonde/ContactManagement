IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_UpdateContact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_UpdateContact]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_UpdateContact]
	@ContactID INT,
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100),
	@PhoneNumber VARCHAR(15),
	@Email VARCHAR(50),
	@UpdatedDate DATETIME,
	@Status BIT
	
AS	
	
BEGIN
	
	SET NOCOUNT ON;

UPDATE [dbo].[Contact]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Email] = @Email
      ,[PhoneNumber] = @PhoneNumber
      ,[Status] = @Status
      ,[UpdatedDate] = @UpdatedDate
	 WHERE ContactID=@ContactID

		
	END





