﻿--region Drop Existing Procedures

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping spCFM_DataOption_Insert'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_DataOption_Insert has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_DataOption_Insert') IS NOT NULL
	DROP PROCEDURE spCFM_DataOption_Insert

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT>0 BEGIN
PRINT 'The stored procedure drop has succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The stored procedure drop has failed'
GO

DROP TABLE #tmpErrors
GO
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping spCFM_DataOption_Update'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_DataOption_Update has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_DataOption_Update') IS NOT NULL
	DROP PROCEDURE spCFM_DataOption_Update

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT>0 BEGIN
PRINT 'The stored procedure drop has succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The stored procedure drop has failed'
GO

DROP TABLE #tmpErrors
GO
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping spCFM_DataOption_Delete'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_DataOption_Delete has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_DataOption_Delete') IS NOT NULL
	DROP PROCEDURE spCFM_DataOption_Delete

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT>0 BEGIN
PRINT 'The stored procedure drop has succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The stored procedure drop has failed'
GO

DROP TABLE #tmpErrors
GO
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping spCFM_DataOption_Select'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_DataOption_Select has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_DataOption_Select') IS NOT NULL
	DROP PROCEDURE spCFM_DataOption_Select

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT>0 BEGIN
PRINT 'The stored procedure drop has succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The stored procedure drop has failed'
GO

DROP TABLE #tmpErrors
GO
--endregion

GO

--region [dbo].[spCFM_DataOption_Insert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_DataOption_Insert]
------------------------------------------------------------------------------------------------------------------------

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO

PRINT N'Creating [dbo].[spCFM_DataOption_Insert]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_DataOption_Insert] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_DataOption_Insert]
	@p_DataOptionTypeID int,
	@p_Code varchar(255),
	@p_DisplayValue varchar(255),
	@p_ParentID int,
	@p_SortID int,
	@p_IsSystem bit,
	@p_AdditionalConfigData nvarchar(max),
	@p_ActiveFrom datetime,
	@p_ActiveTo datetime,
	@p_CreatedOn datetime,
	@p_CreatedBy int,
	@p_UpdatedOn datetime,
	@p_UpdatedBy int,
	@p_DataOptionID int OUTPUT
AS

INSERT INTO [dbo].[DataOption] (
	[DataOptionTypeID],
	[Code],
	[DisplayValue],
	[ParentID],
	[SortID],
	[IsSystem],
	[AdditionalConfigData],
	[ActiveFrom],
	[ActiveTo],
	[CreatedOn],
	[CreatedBy],
	[UpdatedOn],
	[UpdatedBy]    
) VALUES (
	@p_DataOptionTypeID,
	@p_Code,
	@p_DisplayValue,
	@p_ParentID,
	@p_SortID,
	@p_IsSystem,
	@p_AdditionalConfigData,
	@p_ActiveFrom,
	@p_ActiveTo,
	@p_CreatedOn,
	@p_CreatedBy,
	@p_UpdatedOn,
	@p_UpdatedBy)

SET @p_DataOptionID = SCOPE_IDENTITY()



GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'Stored procedure creation succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT 'Stored procedure creation failed.'
GO
DROP TABLE #tmpErrors
GO

--endregion

GO

--region [dbo].[spCFM_DataOption_Update]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_DataOption_Update]
------------------------------------------------------------------------------------------------------------------------

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO

PRINT N'Creating [dbo].[spCFM_DataOption_Update]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_DataOption_Update] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_DataOption_Update]
	@p_DataOptionID int,
	@p_DataOptionTypeID int,
	@p_Code varchar(255),
	@p_DisplayValue varchar(255),
	@p_ParentID int,
	@p_SortID int,
	@p_IsSystem bit,
	@p_AdditionalConfigData nvarchar(max),
	@p_ActiveFrom datetime,
	@p_ActiveTo datetime,
	@p_CreatedOn datetime,
	@p_CreatedBy int,
	@p_UpdatedOn datetime,
	@p_UpdatedBy int
AS

UPDATE [dbo].[DataOption] SET
	[DataOptionTypeID] = @p_DataOptionTypeID,
	[Code] = @p_Code,
	[DisplayValue] = @p_DisplayValue,
	[ParentID] = @p_ParentID,
	[SortID] = @p_SortID,
	[IsSystem] = @p_IsSystem,
	[AdditionalConfigData] = @p_AdditionalConfigData,
	[ActiveFrom] = @p_ActiveFrom,
	[ActiveTo] = @p_ActiveTo,
	[CreatedOn] = @p_CreatedOn,
	[CreatedBy] = @p_CreatedBy,
	[UpdatedOn] = @p_UpdatedOn,
	[UpdatedBy] = @p_UpdatedBy
WHERE
	[DataOptionID] = @p_DataOptionID


GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'Stored procedure creation succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT 'Stored procedure creation failed.'
GO
DROP TABLE #tmpErrors
GO

--endregion

GO

--region [dbo].[spCFM_DataOption_Delete]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_DataOption_Delete]
------------------------------------------------------------------------------------------------------------------------

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO

PRINT N'Creating [dbo].[spCFM_DataOption_Delete]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_DataOption_Delete] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_DataOption_Delete]
	@p_DataOptionID int
AS

DELETE FROM
    [dbo].[DataOption]
WHERE
	[DataOptionID] = @p_DataOptionID

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'Stored procedure creation succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT 'Stored procedure creation failed.'
GO
DROP TABLE #tmpErrors
GO

--endregion

GO

--region [dbo].[spCFM_DataOption_Select]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_DataOption_Select]
------------------------------------------------------------------------------------------------------------------------

SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO

PRINT N'Creating [dbo].[spCFM_DataOption_Select]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_DataOption_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_DataOption_Select] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_DataOption_Select]
	@p_DataOptionID int = NULL,
	@p_DataOptionTypeID int = NULL,
	@p_Code varchar(255) = NULL,
	@p_CodeHasValue BIT = 0,
	@p_DisplayValue varchar(255) = NULL,
	@p_DisplayValueHasValue BIT = 0,
	@p_ParentID int = NULL,
	@p_ParentIDHasValue BIT = 0,
	@p_SortID int = NULL,
	@p_IsSystem bit = NULL,
	@p_AdditionalConfigData nvarchar(max) = NULL,
	@p_AdditionalConfigDataHasValue BIT = 0,
	@p_ActiveFrom datetime = NULL,
	@p_ActiveTo datetime = NULL,
	@p_ActiveToHasValue BIT = 0,
	@p_CreatedOn datetime = NULL,
	@p_CreatedBy int = NULL,
	@p_UpdatedOn datetime = NULL,
	@p_UpdatedOnHasValue BIT = 0,
	@p_UpdatedBy int = NULL,
	@p_UpdatedByHasValue BIT = 0
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[DataOptionID],
	[DataOptionTypeID],
	[Code],
	[DisplayValue],
	[ParentID],
	[SortID],
	[IsSystem],
	[AdditionalConfigData],
	[ActiveFrom],
	[ActiveTo],
	[CreatedOn],
	[CreatedBy],
	[UpdatedOn],
	[UpdatedBy]
FROM
    [dbo].[DataOption]
WHERE
	([DataOptionID] = @p_DataOptionID OR @p_DataOptionID IS NULL)
	AND ([DataOptionTypeID] = @p_DataOptionTypeID OR @p_DataOptionTypeID IS NULL)
	AND ([Code] = @p_Code OR (@p_Code IS NULL AND @p_CodeHasValue = 0))
	AND ([DisplayValue] = @p_DisplayValue OR (@p_DisplayValue IS NULL AND @p_DisplayValueHasValue = 0))
	AND ([ParentID] = @p_ParentID OR (@p_ParentID IS NULL AND @p_ParentIDHasValue = 0))
	AND ([SortID] = @p_SortID OR @p_SortID IS NULL)
	AND ([IsSystem] = @p_IsSystem OR @p_IsSystem IS NULL)
	AND ([AdditionalConfigData] = @p_AdditionalConfigData OR (@p_AdditionalConfigData IS NULL AND @p_AdditionalConfigDataHasValue = 0))
	AND ([ActiveFrom] = @p_ActiveFrom OR @p_ActiveFrom IS NULL)
	AND ([ActiveTo] = @p_ActiveTo OR (@p_ActiveTo IS NULL AND @p_ActiveToHasValue = 0))
	AND ([CreatedOn] = @p_CreatedOn OR @p_CreatedOn IS NULL)
	AND ([CreatedBy] = @p_CreatedBy OR @p_CreatedBy IS NULL)
	AND ([UpdatedOn] = @p_UpdatedOn OR (@p_UpdatedOn IS NULL AND @p_UpdatedOnHasValue = 0))
	AND ([UpdatedBy] = @p_UpdatedBy OR (@p_UpdatedBy IS NULL AND @p_UpdatedByHasValue = 0))

GO
IF @@ERROR!=0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'Stored procedure creation succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT 'Stored procedure creation failed.'
GO
DROP TABLE #tmpErrors
GO

--endregion

GO

