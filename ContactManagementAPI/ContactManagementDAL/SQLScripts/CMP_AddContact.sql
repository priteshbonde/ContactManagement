IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_AddContact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_AddContact]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_AddContact]
	@ContactId INT,
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100),
	@PhoneNumber VARCHAR(15),
	@Email VARCHAR(50),
	@CreatedDate DATETIME,
	@UpdatedDate DATETIME,
	@Status BIT
	
AS	
	
BEGIN
	


INSERT INTO [dbo].[Contact]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[PhoneNumber]
           ,[Status]
           ,[UpdatedDate]
           ,[CreatedDate])
     VALUES
           (@FirstName,
			   @LastName, 
			   @Email, 
			   @PhoneNumber, 
			   @Status, 
			   @UpdatedDate,
			   @CreatedDate
		   )

		SELECT  SCOPE_IDENTITY()
	END





