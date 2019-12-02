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
PRINT N'Dropping spCFM_BankTransaction_Insert'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_BankTransaction_Insert has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_BankTransaction_Insert') IS NOT NULL
	DROP PROCEDURE spCFM_BankTransaction_Insert

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
PRINT N'Dropping spCFM_BankTransaction_Update'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_BankTransaction_Update has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_BankTransaction_Update') IS NOT NULL
	DROP PROCEDURE spCFM_BankTransaction_Update

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
PRINT N'Dropping spCFM_BankTransaction_Delete'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_BankTransaction_Delete has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_BankTransaction_Delete') IS NOT NULL
	DROP PROCEDURE spCFM_BankTransaction_Delete

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
PRINT N'Dropping spCFM_BankTransaction_Select'
GO
IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
BEGIN
    RAISERROR ('The procedure spCFM_BankTransaction_Select has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to drop the procedure.',16,1)
    INSERT INTO #tmpErrors (Error) SELECT 1
END
GO

IF OBJECT_ID(N'spCFM_BankTransaction_Select') IS NOT NULL
	DROP PROCEDURE spCFM_BankTransaction_Select

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

--region [dbo].[spCFM_BankTransaction_Insert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_BankTransaction_Insert]
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

PRINT N'Creating [dbo].[spCFM_BankTransaction_Insert]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Insert', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_BankTransaction_Insert] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_BankTransaction_Insert]
	@p_BankAccountID int,
	@p_TransactionDate int,
	@p_AccountNumber varchar(12),
	@p_AccountName datetime,
	@p_CurrencyCode char(3),
	@p_ClosingBalanace decimal(19, 3),
	@p_TransactionAmount decimal(19, 3),
	@p_TransactionCode char(3),
	@p_Narrative varchar(500),
	@p_SerialNumber int,
	@p_SegmentAccountNumber varchar(50),
	@p_PaymentTransactionID varchar(50),
	@p_InstructionID varchar(50),
	@p_ValueDate int,
	@p_TransactionDateTimeUTC datetime,
	@p_DebtorName varchar(200),
	@p_CreditorName varchar(200),
	@p_EndToEndID varchar(200),
	@p_RemittanceInformation1 varchar(200),
	@p_RemittanceInfoformation2 varchar(200),
	@p_PayiDType varchar(4),
	@p_PayID varchar(256),
	@p_ReversalreasonCode varchar(256),
	@p_OriginalTransactionID varchar(50),
	@p_IsActive bit,
	@p_CreatedBy int,
	@p_CreatedOn datetime,
	@p_UpdatedBy int,
	@p_UpdatedOn datetime,
	@p_BankTransactionID int OUTPUT
AS

INSERT INTO [dbo].[BankTransaction] (
	[BankAccountID],
	[TransactionDate],
	[AccountNumber],
	[AccountName],
	[CurrencyCode],
	[ClosingBalanace],
	[TransactionAmount],
	[TransactionCode],
	[Narrative],
	[SerialNumber],
	[SegmentAccountNumber],
	[PaymentTransactionID],
	[InstructionID],
	[ValueDate],
	[TransactionDateTimeUTC],
	[DebtorName],
	[CreditorName],
	[EndToEndID],
	[RemittanceInformation1],
	[RemittanceInfoformation2],
	[PayiDType],
	[PayID],
	[ReversalreasonCode],
	[OriginalTransactionID],
	[IsActive],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]    
) VALUES (
	@p_BankAccountID,
	@p_TransactionDate,
	@p_AccountNumber,
	@p_AccountName,
	@p_CurrencyCode,
	@p_ClosingBalanace,
	@p_TransactionAmount,
	@p_TransactionCode,
	@p_Narrative,
	@p_SerialNumber,
	@p_SegmentAccountNumber,
	@p_PaymentTransactionID,
	@p_InstructionID,
	@p_ValueDate,
	@p_TransactionDateTimeUTC,
	@p_DebtorName,
	@p_CreditorName,
	@p_EndToEndID,
	@p_RemittanceInformation1,
	@p_RemittanceInfoformation2,
	@p_PayiDType,
	@p_PayID,
	@p_ReversalreasonCode,
	@p_OriginalTransactionID,
	@p_IsActive,
	@p_CreatedBy,
	@p_CreatedOn,
	@p_UpdatedBy,
	@p_UpdatedOn)

SET @p_BankTransactionID = SCOPE_IDENTITY()



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

--region [dbo].[spCFM_BankTransaction_Update]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_BankTransaction_Update]
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

PRINT N'Creating [dbo].[spCFM_BankTransaction_Update]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Update', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_BankTransaction_Update] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_BankTransaction_Update]
	@p_BankTransactionID int,
	@p_BankAccountID int,
	@p_TransactionDate int,
	@p_AccountNumber varchar(12),
	@p_AccountName datetime,
	@p_CurrencyCode char(3),
	@p_ClosingBalanace decimal(19, 3),
	@p_TransactionAmount decimal(19, 3),
	@p_TransactionCode char(3),
	@p_Narrative varchar(500),
	@p_SerialNumber int,
	@p_SegmentAccountNumber varchar(50),
	@p_PaymentTransactionID varchar(50),
	@p_InstructionID varchar(50),
	@p_ValueDate int,
	@p_TransactionDateTimeUTC datetime,
	@p_DebtorName varchar(200),
	@p_CreditorName varchar(200),
	@p_EndToEndID varchar(200),
	@p_RemittanceInformation1 varchar(200),
	@p_RemittanceInfoformation2 varchar(200),
	@p_PayiDType varchar(4),
	@p_PayID varchar(256),
	@p_ReversalreasonCode varchar(256),
	@p_OriginalTransactionID varchar(50),
	@p_IsActive bit,
	@p_CreatedBy int,
	@p_CreatedOn datetime,
	@p_UpdatedBy int,
	@p_UpdatedOn datetime
AS

UPDATE [dbo].[BankTransaction] SET
	[BankAccountID] = @p_BankAccountID,
	[TransactionDate] = @p_TransactionDate,
	[AccountNumber] = @p_AccountNumber,
	[AccountName] = @p_AccountName,
	[CurrencyCode] = @p_CurrencyCode,
	[ClosingBalanace] = @p_ClosingBalanace,
	[TransactionAmount] = @p_TransactionAmount,
	[TransactionCode] = @p_TransactionCode,
	[Narrative] = @p_Narrative,
	[SerialNumber] = @p_SerialNumber,
	[SegmentAccountNumber] = @p_SegmentAccountNumber,
	[PaymentTransactionID] = @p_PaymentTransactionID,
	[InstructionID] = @p_InstructionID,
	[ValueDate] = @p_ValueDate,
	[TransactionDateTimeUTC] = @p_TransactionDateTimeUTC,
	[DebtorName] = @p_DebtorName,
	[CreditorName] = @p_CreditorName,
	[EndToEndID] = @p_EndToEndID,
	[RemittanceInformation1] = @p_RemittanceInformation1,
	[RemittanceInfoformation2] = @p_RemittanceInfoformation2,
	[PayiDType] = @p_PayiDType,
	[PayID] = @p_PayID,
	[ReversalreasonCode] = @p_ReversalreasonCode,
	[OriginalTransactionID] = @p_OriginalTransactionID,
	[IsActive] = @p_IsActive,
	[CreatedBy] = @p_CreatedBy,
	[CreatedOn] = @p_CreatedOn,
	[UpdatedBy] = @p_UpdatedBy,
	[UpdatedOn] = @p_UpdatedOn
WHERE
	[BankTransactionID] = @p_BankTransactionID


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

--region [dbo].[spCFM_BankTransaction_Delete]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_BankTransaction_Delete]
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

PRINT N'Creating [dbo].[spCFM_BankTransaction_Delete]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Delete', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_BankTransaction_Delete] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_BankTransaction_Delete]
	@p_BankTransactionID int
AS

DELETE FROM
    [dbo].[BankTransaction]
WHERE
	[BankTransactionID] = @p_BankTransactionID

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

--region [dbo].[spCFM_BankTransaction_Select]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   prady using CodeSmith: v7.1.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10
-- Procedure Name: [dbo].[spCFM_BankTransaction_Select]
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

PRINT N'Creating [dbo].[spCFM_BankTransaction_Select]'
GO

IF EXISTS(SELECT 1 FROM fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'PROCEDURE', 'spCFM_BankTransaction_Select', default, default) WHERE name = 'CustomProcedure' and value = '1')
    BEGIN
        RAISERROR ('The procedure [dbo].[spCFM_BankTransaction_Select] has an Extended Property "CustomProcedure" which means is has been customized. Please review and remove the property if you wish to create the stored procedure.',16,1)
        INSERT INTO #tmpErrors (Error) SELECT 1
    END
GO

CREATE PROCEDURE [dbo].[spCFM_BankTransaction_Select]
	@p_BankTransactionID int = NULL,
	@p_BankAccountID int = NULL,
	@p_BankAccountIDHasValue BIT = 0,
	@p_TransactionDate int = NULL,
	@p_AccountNumber varchar(12) = NULL,
	@p_AccountName datetime = NULL,
	@p_CurrencyCode char(3) = NULL,
	@p_ClosingBalanace decimal(19, 3) = NULL,
	@p_TransactionAmount decimal(19, 3) = NULL,
	@p_TransactionCode char(3) = NULL,
	@p_Narrative varchar(500) = NULL,
	@p_NarrativeHasValue BIT = 0,
	@p_SerialNumber int = NULL,
	@p_SerialNumberHasValue BIT = 0,
	@p_SegmentAccountNumber varchar(50) = NULL,
	@p_SegmentAccountNumberHasValue BIT = 0,
	@p_PaymentTransactionID varchar(50) = NULL,
	@p_PaymentTransactionIDHasValue BIT = 0,
	@p_InstructionID varchar(50) = NULL,
	@p_InstructionIDHasValue BIT = 0,
	@p_ValueDate int = NULL,
	@p_ValueDateHasValue BIT = 0,
	@p_TransactionDateTimeUTC datetime = NULL,
	@p_TransactionDateTimeUTCHasValue BIT = 0,
	@p_DebtorName varchar(200) = NULL,
	@p_DebtorNameHasValue BIT = 0,
	@p_CreditorName varchar(200) = NULL,
	@p_CreditorNameHasValue BIT = 0,
	@p_EndToEndID varchar(200) = NULL,
	@p_EndToEndIDHasValue BIT = 0,
	@p_RemittanceInformation1 varchar(200) = NULL,
	@p_RemittanceInformation1HasValue BIT = 0,
	@p_RemittanceInfoformation2 varchar(200) = NULL,
	@p_RemittanceInfoformation2HasValue BIT = 0,
	@p_PayiDType varchar(4) = NULL,
	@p_PayiDTypeHasValue BIT = 0,
	@p_PayID varchar(256) = NULL,
	@p_PayIDHasValue BIT = 0,
	@p_ReversalreasonCode varchar(256) = NULL,
	@p_ReversalreasonCodeHasValue BIT = 0,
	@p_OriginalTransactionID varchar(50) = NULL,
	@p_OriginalTransactionIDHasValue BIT = 0,
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
	[BankTransactionID],
	[BankAccountID],
	[TransactionDate],
	[AccountNumber],
	[AccountName],
	[CurrencyCode],
	[ClosingBalanace],
	[TransactionAmount],
	[TransactionCode],
	[Narrative],
	[SerialNumber],
	[SegmentAccountNumber],
	[PaymentTransactionID],
	[InstructionID],
	[ValueDate],
	[TransactionDateTimeUTC],
	[DebtorName],
	[CreditorName],
	[EndToEndID],
	[RemittanceInformation1],
	[RemittanceInfoformation2],
	[PayiDType],
	[PayID],
	[ReversalreasonCode],
	[OriginalTransactionID],
	[IsActive],
	[CreatedBy],
	[CreatedOn],
	[UpdatedBy],
	[UpdatedOn]
FROM
    [dbo].[BankTransaction]
WHERE
	([BankTransactionID] = @p_BankTransactionID OR @p_BankTransactionID IS NULL)
	AND ([BankAccountID] = @p_BankAccountID OR (@p_BankAccountID IS NULL AND @p_BankAccountIDHasValue = 0))
	AND ([TransactionDate] = @p_TransactionDate OR @p_TransactionDate IS NULL)
	AND ([AccountNumber] = @p_AccountNumber OR @p_AccountNumber IS NULL)
	AND ([AccountName] = @p_AccountName OR @p_AccountName IS NULL)
	AND ([CurrencyCode] = @p_CurrencyCode OR @p_CurrencyCode IS NULL)
	AND ([ClosingBalanace] = @p_ClosingBalanace OR @p_ClosingBalanace IS NULL)
	AND ([TransactionAmount] = @p_TransactionAmount OR @p_TransactionAmount IS NULL)
	AND ([TransactionCode] = @p_TransactionCode OR @p_TransactionCode IS NULL)
	AND ([Narrative] = @p_Narrative OR (@p_Narrative IS NULL AND @p_NarrativeHasValue = 0))
	AND ([SerialNumber] = @p_SerialNumber OR (@p_SerialNumber IS NULL AND @p_SerialNumberHasValue = 0))
	AND ([SegmentAccountNumber] = @p_SegmentAccountNumber OR (@p_SegmentAccountNumber IS NULL AND @p_SegmentAccountNumberHasValue = 0))
	AND ([PaymentTransactionID] = @p_PaymentTransactionID OR (@p_PaymentTransactionID IS NULL AND @p_PaymentTransactionIDHasValue = 0))
	AND ([InstructionID] = @p_InstructionID OR (@p_InstructionID IS NULL AND @p_InstructionIDHasValue = 0))
	AND ([ValueDate] = @p_ValueDate OR (@p_ValueDate IS NULL AND @p_ValueDateHasValue = 0))
	AND ([TransactionDateTimeUTC] = @p_TransactionDateTimeUTC OR (@p_TransactionDateTimeUTC IS NULL AND @p_TransactionDateTimeUTCHasValue = 0))
	AND ([DebtorName] = @p_DebtorName OR (@p_DebtorName IS NULL AND @p_DebtorNameHasValue = 0))
	AND ([CreditorName] = @p_CreditorName OR (@p_CreditorName IS NULL AND @p_CreditorNameHasValue = 0))
	AND ([EndToEndID] = @p_EndToEndID OR (@p_EndToEndID IS NULL AND @p_EndToEndIDHasValue = 0))
	AND ([RemittanceInformation1] = @p_RemittanceInformation1 OR (@p_RemittanceInformation1 IS NULL AND @p_RemittanceInformation1HasValue = 0))
	AND ([RemittanceInfoformation2] = @p_RemittanceInfoformation2 OR (@p_RemittanceInfoformation2 IS NULL AND @p_RemittanceInfoformation2HasValue = 0))
	AND ([PayiDType] = @p_PayiDType OR (@p_PayiDType IS NULL AND @p_PayiDTypeHasValue = 0))
	AND ([PayID] = @p_PayID OR (@p_PayID IS NULL AND @p_PayIDHasValue = 0))
	AND ([ReversalreasonCode] = @p_ReversalreasonCode OR (@p_ReversalreasonCode IS NULL AND @p_ReversalreasonCodeHasValue = 0))
	AND ([OriginalTransactionID] = @p_OriginalTransactionID OR (@p_OriginalTransactionID IS NULL AND @p_OriginalTransactionIDHasValue = 0))
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

