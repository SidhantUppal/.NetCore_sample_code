--region Drop Existing Procedures

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
PRINT N'Dropping spCFM_Gl_Insert'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_Gl_Insert has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_Gl_Insert') IS NOT NULL
	DROP PROCEDURE spCFM_Gl_Insert

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
PRINT N'Dropping spCFM_Gl_Update'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_Gl_Update has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_Gl_Update') IS NOT NULL
	DROP PROCEDURE spCFM_Gl_Update

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
PRINT N'Dropping spCFM_Gl_Delete'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_Gl_Delete has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_Gl_Delete') IS NOT NULL
	DROP PROCEDURE spCFM_Gl_Delete

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
PRINT N'Dropping spCFM_Gl_Select'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_Gl_Select has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_Gl_Select') IS NOT NULL
	DROP PROCEDURE spCFM_Gl_Select

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

--region [dbo].[spCFM_Gl_Insert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_Gl_Insert]
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

PRINT N'Creating [dbo].[spCFM_Gl_Insert]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_Gl_Insert] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_Gl_Insert]
	@p_JournalDate datetime,
	@p_PostingDate datetime,
	@p_GLAccountID int,
	@p_TransactionTypeID int,
	@p_GLCostCentreEntityID int,
	@p_BankTransactionID int,
	@p_CategoryID int,
	@p_JournalNumber int,
	@p_Narration varchar(255),
	@p_DocRef varchar(50),
	@p_CurrencyCode char(3),
	@p_ExGstAMount decimal(19, 3),
	@p_GSTAmount decimal(19, 3),
	@p_DRAmount decimal(19, 3),
	@p_CRAmount decimal(19, 3),
	@p_HouseBudgetID int,
	@p_ClientBudgetID int,
	@p_IsActive bit,
	@p_CreatedBy int,
	@p_CreatedOn datetime,
	@p_UpdatedBy int,
	@p_UpdatedOn datetime,
	@p_GLID int OUTPUT
AS

INSERT INTO [dbo].[GL] (
	[JournalDate],
	[PostingDate],
	[GLAccountID],
	[TransactionTypeID],
	[GLCostCentreEntityID],
	[BankTransactionID],
	[CategoryID],
	[JournalNumber],
	[Narration],
	[DocRef],
	[CurrencyCode],
	[ExGstAMount],
	[GSTAmount],
	[DRAmount],
	[CRAmount],
	[HouseBudgetID],
	[ClientBudgetID],
	[IsActive],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]    
) VALUES (
	@p_JournalDate,
	@p_PostingDate,
	@p_GLAccountID,
	@p_TransactionTypeID,
	@p_GLCostCentreEntityID,
	@p_BankTransactionID,
	@p_CategoryID,
	@p_JournalNumber,
	@p_Narration,
	@p_DocRef,
	@p_CurrencyCode,
	@p_ExGstAMount,
	@p_GSTAmount,
	@p_DRAmount,
	@p_CRAmount,
	@p_HouseBudgetID,
	@p_ClientBudgetID,
	@p_IsActive,
	@p_CreatedBy,
	@p_CreatedOn,
	@p_UpdatedBy,
	@p_UpdatedOn)

SET @p_GLID = SCOPE_IDENTITY()



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

--region [dbo].[spCFM_Gl_Update]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_Gl_Update]
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

PRINT N'Creating [dbo].[spCFM_Gl_Update]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_Gl_Update] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_Gl_Update]
	@p_GLID int,
	@p_JournalDate datetime,
	@p_PostingDate datetime,
	@p_GLAccountID int,
	@p_TransactionTypeID int,
	@p_GLCostCentreEntityID int,
	@p_BankTransactionID int,
	@p_CategoryID int,
	@p_JournalNumber int,
	@p_Narration varchar(255),
	@p_DocRef varchar(50),
	@p_CurrencyCode char(3),
	@p_ExGstAMount decimal(19, 3),
	@p_GSTAmount decimal(19, 3),
	@p_DRAmount decimal(19, 3),
	@p_CRAmount decimal(19, 3),
	@p_HouseBudgetID int,
	@p_ClientBudgetID int,
	@p_IsActive bit,
	@p_CreatedBy int,
	@p_CreatedOn datetime,
	@p_UpdatedBy int,
	@p_UpdatedOn datetime
AS

UPDATE [dbo].[GL] SET
	[JournalDate] = @p_JournalDate,
	[PostingDate] = @p_PostingDate,
	[GLAccountID] = @p_GLAccountID,
	[TransactionTypeID] = @p_TransactionTypeID,
	[GLCostCentreEntityID] = @p_GLCostCentreEntityID,
	[BankTransactionID] = @p_BankTransactionID,
	[CategoryID] = @p_CategoryID,
	[JournalNumber] = @p_JournalNumber,
	[Narration] = @p_Narration,
	[DocRef] = @p_DocRef,
	[CurrencyCode] = @p_CurrencyCode,
	[ExGstAMount] = @p_ExGstAMount,
	[GSTAmount] = @p_GSTAmount,
	[DRAmount] = @p_DRAmount,
	[CRAmount] = @p_CRAmount,
	[HouseBudgetID] = @p_HouseBudgetID,
	[ClientBudgetID] = @p_ClientBudgetID,
	[IsActive] = @p_IsActive,
	[CreatedBy] = @p_CreatedBy,
	[CreatedOn] = @p_CreatedOn,
	[UpdatedBy] = @p_UpdatedBy,
	[UpdatedOn] = @p_UpdatedOn
WHERE
	[GLID] = @p_GLID


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

--region [dbo].[spCFM_Gl_Delete]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_Gl_Delete]
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

PRINT N'Creating [dbo].[spCFM_Gl_Delete]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_Gl_Delete] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_Gl_Delete]
	@p_GLID int
AS

DELETE FROM
    [dbo].[GL]
WHERE
	[GLID] = @p_GLID

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

--region [dbo].[spCFM_Gl_Select]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_Gl_Select]
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

PRINT N'Creating [dbo].[spCFM_Gl_Select]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_Gl_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_Gl_Select] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_Gl_Select]
	@p_GLID int = NULL,
	@p_JournalDate datetime = NULL,
	@p_PostingDate datetime = NULL,
	@p_PostingDateHasValue BIT = 0,
	@p_GLAccountID int = NULL,
	@p_TransactionTypeID int = NULL,
	@p_GLCostCentreEntityID int = NULL,
	@p_GLCostCentreEntityIDHasValue BIT = 0,
	@p_BankTransactionID int = NULL,
	@p_BankTransactionIDHasValue BIT = 0,
	@p_CategoryID int = NULL,
	@p_CategoryIDHasValue BIT = 0,
	@p_JournalNumber int = NULL,
	@p_Narration varchar(255) = NULL,
	@p_DocRef varchar(50) = NULL,
	@p_CurrencyCode char(3) = NULL,
	@p_ExGstAMount decimal(19, 3) = NULL,
	@p_ExGstAMountHasValue BIT = 0,
	@p_GSTAmount decimal(19, 3) = NULL,
	@p_GSTAmountHasValue BIT = 0,
	@p_DRAmount decimal(19, 3) = NULL,
	@p_DRAmountHasValue BIT = 0,
	@p_CRAmount decimal(19, 3) = NULL,
	@p_CRAmountHasValue BIT = 0,
	@p_HouseBudgetID int = NULL,
	@p_HouseBudgetIDHasValue BIT = 0,
	@p_ClientBudgetID int = NULL,
	@p_ClientBudgetIDHasValue BIT = 0,
	@p_IsActive bit = NULL,
	@p_CreatedBy int = NULL,
	@p_CreatedOn datetime = NULL,
	@p_UpdatedBy int = NULL,
	@p_UpdatedByHasValue BIT = 0,
	@p_UpdatedOn datetime = NULL,
	@p_UpdatedOnHasValue BIT = 0
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[GLID],
	[JournalDate],
	[PostingDate],
	[GLAccountID],
	[TransactionTypeID],
	[GLCostCentreEntityID],
	[BankTransactionID],
	[CategoryID],
	[JournalNumber],
	[Narration],
	[DocRef],
	[CurrencyCode],
	[ExGstAMount],
	[GSTAmount],
	[DRAmount],
	[CRAmount],
	[HouseBudgetID],
	[ClientBudgetID],
	[IsActive],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]
FROM
    [dbo].[GL]
WHERE
	([GLID] = @p_GLID OR @p_GLID IS NULL)
	AND ([JournalDate] = @p_JournalDate OR @p_JournalDate IS NULL)
	AND ([PostingDate] = @p_PostingDate OR (@p_PostingDate IS NULL AND @p_PostingDateHasValue = 0))
	AND ([GLAccountID] = @p_GLAccountID OR @p_GLAccountID IS NULL)
	AND ([TransactionTypeID] = @p_TransactionTypeID OR @p_TransactionTypeID IS NULL)
	AND ([GLCostCentreEntityID] = @p_GLCostCentreEntityID OR (@p_GLCostCentreEntityID IS NULL AND @p_GLCostCentreEntityIDHasValue = 0))
	AND ([BankTransactionID] = @p_BankTransactionID OR (@p_BankTransactionID IS NULL AND @p_BankTransactionIDHasValue = 0))
	AND ([CategoryID] = @p_CategoryID OR (@p_CategoryID IS NULL AND @p_CategoryIDHasValue = 0))
	AND ([JournalNumber] = @p_JournalNumber OR @p_JournalNumber IS NULL)
	AND ([Narration] = @p_Narration OR @p_Narration IS NULL)
	AND ([DocRef] = @p_DocRef OR @p_DocRef IS NULL)
	AND ([CurrencyCode] = @p_CurrencyCode OR @p_CurrencyCode IS NULL)
	AND ([ExGstAMount] = @p_ExGstAMount OR (@p_ExGstAMount IS NULL AND @p_ExGstAMountHasValue = 0))
	AND ([GSTAmount] = @p_GSTAmount OR (@p_GSTAmount IS NULL AND @p_GSTAmountHasValue = 0))
	AND ([DRAmount] = @p_DRAmount OR (@p_DRAmount IS NULL AND @p_DRAmountHasValue = 0))
	AND ([CRAmount] = @p_CRAmount OR (@p_CRAmount IS NULL AND @p_CRAmountHasValue = 0))
	AND ([HouseBudgetID] = @p_HouseBudgetID OR (@p_HouseBudgetID IS NULL AND @p_HouseBudgetIDHasValue = 0))
	AND ([ClientBudgetID] = @p_ClientBudgetID OR (@p_ClientBudgetID IS NULL AND @p_ClientBudgetIDHasValue = 0))
	AND ([IsActive] = @p_IsActive OR @p_IsActive IS NULL)
	AND ([CreatedBy] = @p_CreatedBy OR @p_CreatedBy IS NULL)
	AND ([CreatedOn] = @p_CreatedOn OR @p_CreatedOn IS NULL)
	AND ([UpdatedBy] = @p_UpdatedBy OR (@p_UpdatedBy IS NULL AND @p_UpdatedByHasValue = 0))
	AND ([UpdatedOn] = @p_UpdatedOn OR (@p_UpdatedOn IS NULL AND @p_UpdatedOnHasValue = 0))

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

