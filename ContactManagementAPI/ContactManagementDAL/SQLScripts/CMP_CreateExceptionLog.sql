IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMP_CreateExceptionLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CMP_CreateExceptionLog]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CMP_CreateExceptionLog]
	@ExceptionMessage VARCHAR(500),
	@CreatedDate DATETIME
	
AS	
	
BEGIN
	


INSERT INTO [dbo].[ExceptionLog]
           ([ExceptionMessage]
           ,[CreatedDate])
     VALUES
           (@ExceptionMessage,
           @CreatedDate)

		SELECT  SCOPE_IDENTITY()
	END





