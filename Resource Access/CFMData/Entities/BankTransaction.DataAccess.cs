﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BankTransaction.cs'.
//
//     Template: EditableRoot.DataAccess.StoredProcedures.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
 using Dapper;

namespace CFMData
{
	public partial class BankTransaction
	{
    
		private BankTransaction DataPortal_Fetch(BankTransactionCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_BankAccountIDHasValue", criteria.BankAccountIDHasValue);
                command.Parameters.AddWithValue("@p_NarrativeHasValue", criteria.NarrativeHasValue);
                command.Parameters.AddWithValue("@p_SerialNumberHasValue", criteria.SerialNumberHasValue);
                command.Parameters.AddWithValue("@p_SegmentAccountNumberHasValue", criteria.SegmentAccountNumberHasValue);
                command.Parameters.AddWithValue("@p_PaymentTransactionIDHasValue", criteria.PaymentTransactionIDHasValue);
                command.Parameters.AddWithValue("@p_InstructionIDHasValue", criteria.InstructionIDHasValue);
                command.Parameters.AddWithValue("@p_ValueDateHasValue", criteria.ValueDateHasValue);
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTCHasValue", criteria.TransactionDateTimeUTCHasValue);
                command.Parameters.AddWithValue("@p_DebtorNameHasValue", criteria.DebtorNameHasValue);
                command.Parameters.AddWithValue("@p_CreditorNameHasValue", criteria.CreditorNameHasValue);
                command.Parameters.AddWithValue("@p_EndToEndIDHasValue", criteria.EndToEndIDHasValue);
                command.Parameters.AddWithValue("@p_RemittanceInformation1HasValue", criteria.RemittanceInformation1HasValue);
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2HasValue", criteria.RemittanceInfoformation2HasValue);
                command.Parameters.AddWithValue("@p_PayiDTypeHasValue", criteria.PayiDTypeHasValue);
                command.Parameters.AddWithValue("@p_PayIDHasValue", criteria.PayIDHasValue);
                command.Parameters.AddWithValue("@p_ReversalreasonCodeHasValue", criteria.ReversalreasonCodeHasValue);
                command.Parameters.AddWithValue("@p_OriginalTransactionIDHasValue", criteria.OriginalTransactionIDHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<BankTransaction>();                       
						if(reader.Read())
						{
							return GetBankTransaction(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.BankTransaction' using the following criteria: {0}.", criteria));
					}
				}
			}
			OnFetched();
		}

       // [Transactional(TransactionalTypes.TransactionScope)]
		protected   void DataPortal_Insert()
		{
			bool cancel = false;
			OnInserting(ref cancel);
			if (cancel) return;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				
				using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters["@p_BankTransactionID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					command.ExecuteNonQuery();                  
					_bankTransactionIDProperty=(System.Int32)command.Parameters["@p_BankTransactionID"].Value;
                    
				}
                
				UpdateChildren(this, connection,trans);
				
				trans.Commit();
			}
			catch(Exception ex)
			{
				trans.Rollback();
				throw;
			}
			
		}
			

			OnInserted();

		}

       // [Transactional(TransactionalTypes.TransactionScope)]
		protected   void DataPortal_Update()
		{
			bool cancel = false;
			OnUpdating(ref cancel);
			if (cancel) return;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
					int result = command.ExecuteNonQuery();
					if (result == 0)
						throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

				}
				UpdateChildren(this, connection,trans);
				//FieldManager.UpdateChildren(this, connection);
				trans.Commit();
			}
			catch(Exception ex)
			{
				trans.Rollback();
				throw;
			}
			
		}

			OnUpdated();
		}
		protected   void UpdateChildren(BankTransaction parent,SqlConnection connection,SqlTransaction trans)
		{
		
		
			
			if(_glsPropertyChecked )
			{
				if(_glsProperty!=null)
				{
				
					foreach (Gl obj in _glsProperty)
					{
						if (obj.IsNew)
						{
							obj.Child_Insert(parent, connection,trans);
						}
						else
						{
							if (obj.IsDirty ||  obj.IsChildDirty())
							{							
								obj.Child_Update(parent, connection,trans);
							}
						}
					}
				}
					
 
			}


		}

		protected   void DataPortal_DeleteSelf()
		{
			bool cancel = false;
			OnSelfDeleting(ref cancel);
			if (cancel) return;            
			DataPortal_Delete(new BankTransactionCriteria (BankTransactionID));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(BankTransactionCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
		
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
		}
		
		 #region Child_Insert
        /// <summary>
        /// Inserts data into the data base using the information in the current 
        ///    CSLA editable child business object of type <see cref="BankTransaction"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters["@p_BankTransactionID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _bankTransactionIDProperty=(System.Int32)command.Parameters["@p_BankTransactionID"].Value;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        public void Child_Insert(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(applicationUser, null, connection,trans);
        }


        public void Child_Insert(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, bankAccount, connection,trans);
        }


        public void Child_Insert(ApplicationUser applicationUser, BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(applicationUser, bankAccount, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters["@p_BankTransactionID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _bankTransactionIDProperty=(System.Int32)command.Parameters["@p_BankTransactionID"].Value;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                _bankAccountIDProperty= bankAccount.BankAccountID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                _createdByProperty= applicationUser.ApplicationUserID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                _updatedByProperty= applicationUser.ApplicationUserID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildInserted() and insert this child manually.
            // UpdateChildren(this, connection);

            OnChildInserted();
        }

        #endregion

        #region Child_Update

        /// <summary>
        /// Updates the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="BankTransaction"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
            }

            UpdateChildren(this, connection,trans);

            OnChildUpdated();
        }

        public void Child_Update(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(applicationUser, null, connection,trans);
        }


        public void Child_Update(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, bankAccount, connection,trans);
        }

 
        public void Child_Update(ApplicationUser applicationUser, BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(applicationUser, bankAccount, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankTransaction_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankTransactionID", this.BankTransactionID);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID));
                command.Parameters.AddWithValue("@p_TransactionDate", this.TransactionDate);
                command.Parameters.AddWithValue("@p_AccountNumber", this.AccountNumber);
                command.Parameters.AddWithValue("@p_AccountName", this.AccountName);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ClosingBalanace", this.ClosingBalanace);
                command.Parameters.AddWithValue("@p_TransactionAmount", this.TransactionAmount);
                command.Parameters.AddWithValue("@p_TransactionCode", this.TransactionCode);
                command.Parameters.AddWithValue("@p_Narrative", ADOHelper.NullCheck(this.Narrative));
                command.Parameters.AddWithValue("@p_SerialNumber", ADOHelper.NullCheck(this.SerialNumber));
                command.Parameters.AddWithValue("@p_SegmentAccountNumber", ADOHelper.NullCheck(this.SegmentAccountNumber));
                command.Parameters.AddWithValue("@p_PaymentTransactionID", ADOHelper.NullCheck(this.PaymentTransactionID));
                command.Parameters.AddWithValue("@p_InstructionID", ADOHelper.NullCheck(this.InstructionID));
                command.Parameters.AddWithValue("@p_ValueDate", ADOHelper.NullCheck(this.ValueDate));
                command.Parameters.AddWithValue("@p_TransactionDateTimeUTC", ADOHelper.NullCheck(this.TransactionDateTimeUTC));
                command.Parameters.AddWithValue("@p_DebtorName", ADOHelper.NullCheck(this.DebtorName));
                command.Parameters.AddWithValue("@p_CreditorName", ADOHelper.NullCheck(this.CreditorName));
                command.Parameters.AddWithValue("@p_EndToEndID", ADOHelper.NullCheck(this.EndToEndID));
                command.Parameters.AddWithValue("@p_RemittanceInformation1", ADOHelper.NullCheck(this.RemittanceInformation1));
                command.Parameters.AddWithValue("@p_RemittanceInfoformation2", ADOHelper.NullCheck(this.RemittanceInfoformation2));
                command.Parameters.AddWithValue("@p_PayiDType", ADOHelper.NullCheck(this.PayiDType));
                command.Parameters.AddWithValue("@p_PayID", ADOHelper.NullCheck(this.PayID));
                command.Parameters.AddWithValue("@p_ReversalreasonCode", ADOHelper.NullCheck(this.ReversalreasonCode));
                command.Parameters.AddWithValue("@p_OriginalTransactionID", ADOHelper.NullCheck(this.OriginalTransactionID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                    _bankAccountIDProperty= bankAccount.BankAccountID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                    _createdByProperty= applicationUser.ApplicationUserID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                    _updatedByProperty= applicationUser.ApplicationUserID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildUpdated() and update this child manually.
            // UpdateChildren(this, connection);

            OnChildUpdated();
        }
        #endregion

        /// <summary>
        /// Deletes the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="BankTransaction"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new BankTransactionCriteria (BankTransactionID), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  BankTransactionDTO dt=new BankTransactionDTO();
			dt.BankTransactionID =this.BankTransactionID ;
			dt.BankAccountID =this.BankAccountID ;
			dt.TransactionDate =this.TransactionDate ;
			dt.AccountNumber =this.AccountNumber ;
			dt.AccountName =this.AccountName ;
			dt.CurrencyCode =this.CurrencyCode ;
			dt.ClosingBalanace =this.ClosingBalanace ;
			dt.TransactionAmount =this.TransactionAmount ;
			dt.TransactionCode =this.TransactionCode ;
			dt.Narrative =this.Narrative ;
			dt.SerialNumber =this.SerialNumber ;
			dt.SegmentAccountNumber =this.SegmentAccountNumber ;
			dt.PaymentTransactionID =this.PaymentTransactionID ;
			dt.InstructionID =this.InstructionID ;
			dt.ValueDate =this.ValueDate ;
			dt.TransactionDateTimeUTC =this.TransactionDateTimeUTC ;
			dt.DebtorName =this.DebtorName ;
			dt.CreditorName =this.CreditorName ;
			dt.EndToEndID =this.EndToEndID ;
			dt.RemittanceInformation1 =this.RemittanceInformation1 ;
			dt.RemittanceInfoformation2 =this.RemittanceInfoformation2 ;
			dt.PayiDType =this.PayiDType ;
			dt.PayID =this.PayID ;
			dt.ReversalreasonCode =this.ReversalreasonCode ;
			dt.OriginalTransactionID =this.OriginalTransactionID ;
			dt.IsActive =this.IsActive ;
			dt.CreatedBy =this.CreatedBy ;
			dt.CreatedOn =this.CreatedOn ;
			dt.UpdatedBy =this.UpdatedBy ;
			dt.UpdatedOn =this.UpdatedOn ;
   //LoadProperty(_currentDto, dt);
  this.CurrentDTO = dt;

		}
		/*
        private void Map(SafeDataReader reader)
        {
            bool cancel = false;
            OnMapping(reader, ref cancel);
            if (cancel) return;

            using(BypassPropertyChecks)
            {
                LoadProperty(_bankTransactionIDProperty, reader["BankTransactionID"]);
                LoadProperty(_bankAccountIDProperty, reader["BankAccountID"]);
                LoadProperty(_transactionDateProperty, reader["TransactionDate"]);
                LoadProperty(_accountNumberProperty, reader["AccountNumber"]);
                LoadProperty(_accountNameProperty, reader["AccountName"]);
                LoadProperty(_currencyCodeProperty, reader["CurrencyCode"]);
                LoadProperty(_closingBalanaceProperty, reader["ClosingBalanace"]);
                LoadProperty(_transactionAmountProperty, reader["TransactionAmount"]);
                LoadProperty(_transactionCodeProperty, reader["TransactionCode"]);
                LoadProperty(_narrativeProperty, reader["Narrative"]);
                LoadProperty(_serialNumberProperty, reader["SerialNumber"]);
                LoadProperty(_segmentAccountNumberProperty, reader["SegmentAccountNumber"]);
                LoadProperty(_paymentTransactionIDProperty, reader["PaymentTransactionID"]);
                LoadProperty(_instructionIDProperty, reader["InstructionID"]);
                LoadProperty(_valueDateProperty, reader["ValueDate"]);
                LoadProperty(_transactionDateTimeUTCProperty, reader["TransactionDateTimeUTC"]);
                LoadProperty(_debtorNameProperty, reader["DebtorName"]);
                LoadProperty(_creditorNameProperty, reader["CreditorName"]);
                LoadProperty(_endToEndIDProperty, reader["EndToEndID"]);
                LoadProperty(_remittanceInformation1Property, reader["RemittanceInformation1"]);
                LoadProperty(_remittanceInfoformation2Property, reader["RemittanceInfoformation2"]);
                LoadProperty(_payiDTypeProperty, reader["PayiDType"]);
                LoadProperty(_payIDProperty, reader["PayID"]);
                LoadProperty(_reversalreasonCodeProperty, reader["ReversalreasonCode"]);
                LoadProperty(_originalTransactionIDProperty, reader["OriginalTransactionID"]);
                LoadProperty(_isActiveProperty, reader["IsActive"]);
                LoadProperty(_createdByProperty, reader["CreatedBy"]);
                LoadProperty(_createdOnProperty, reader["CreatedOn"]);
                LoadProperty(_updatedByProperty, reader["UpdatedBy"]);
                LoadProperty(_updatedOnProperty, reader["UpdatedOn"]);
            }	
			InitDTO();
            OnMapped();
        }
        
        private void Child_Fetch(SafeDataReader reader)
        {
            Map(reader);
        }
		*/

        #endregion
	}
}
 