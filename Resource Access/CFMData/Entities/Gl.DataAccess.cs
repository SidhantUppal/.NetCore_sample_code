﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Gl.cs'.
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
	public partial class Gl
	{
    
		private Gl DataPortal_Fetch(GlCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_Gl_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_PostingDateHasValue", criteria.PostingDateHasValue);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityIDHasValue", criteria.GLCostCentreEntityIDHasValue);
                command.Parameters.AddWithValue("@p_BankTransactionIDHasValue", criteria.BankTransactionIDHasValue);
                command.Parameters.AddWithValue("@p_CategoryIDHasValue", criteria.CategoryIDHasValue);
                command.Parameters.AddWithValue("@p_ExGstAMountHasValue", criteria.ExGstAMountHasValue);
                command.Parameters.AddWithValue("@p_GSTAmountHasValue", criteria.GSTAmountHasValue);
                command.Parameters.AddWithValue("@p_DRAmountHasValue", criteria.DRAmountHasValue);
                command.Parameters.AddWithValue("@p_CRAmountHasValue", criteria.CRAmountHasValue);
                command.Parameters.AddWithValue("@p_HouseBudgetIDHasValue", criteria.HouseBudgetIDHasValue);
                command.Parameters.AddWithValue("@p_ClientBudgetIDHasValue", criteria.ClientBudgetIDHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<Gl>();                       
						if(reader.Read())
						{
							return GetGl(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.GL' using the following criteria: {0}.", criteria));
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
				
				using(var command = new SqlCommand("[dbo].[spCFM_Gl_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters["@p_GLID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(this.ClientBudgetID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					command.ExecuteNonQuery();                  
					_glidProperty=(System.Int32)command.Parameters["@p_GLID"].Value;
                    
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
				using(var command = new SqlCommand("[dbo].[spCFM_Gl_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(this.ClientBudgetID));
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
		protected   void UpdateChildren(Gl parent,SqlConnection connection,SqlTransaction trans)
		{
		
		

		}

		protected   void DataPortal_DeleteSelf()
		{
			bool cancel = false;
			OnSelfDeleting(ref cancel);
			if (cancel) return;            
			DataPortal_Delete(new GlCriteria (Glid));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(GlCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_Gl_Delete]", connection))
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
        ///    CSLA editable child business object of type <see cref="Gl"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_Gl_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters["@p_GLID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(this.ClientBudgetID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _glidProperty=(System.Int32)command.Parameters["@p_GLID"].Value;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        public void Child_Insert(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(applicationUser, null, null, null, null, connection,trans);
        }


        public void Child_Insert(BankTransaction bankTransaction, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, bankTransaction, null, null, null, connection,trans);
        }


        public void Child_Insert(Budget budget, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, null, budget, null, null, connection,trans);
        }


        public void Child_Insert(GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, null, null, gLEntity, null, connection,trans);
        }


        public void Child_Insert(TransactionType transactionType, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, null, null, null, transactionType, connection,trans);
        }


        public void Child_Insert(ApplicationUser applicationUser, BankTransaction bankTransaction, Budget budget, GLEntity gLEntity, TransactionType transactionType, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(applicationUser, bankTransaction, budget, gLEntity, transactionType, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_Gl_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters["@p_GLID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", transactionType != null ? transactionType.TransactionTypeID : this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(gLEntity != null ? gLEntity.GLEntityID : this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(bankTransaction != null ? bankTransaction.BankTransactionID : this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(budget != null ? budget.BudgetID : this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(budget != null ? budget.BudgetID : this.ClientBudgetID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _glidProperty=(System.Int32)command.Parameters["@p_GLID"].Value;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(transactionType != null && transactionType.TransactionTypeID != this.TransactionTypeID)
                _transactionTypeIDProperty= transactionType.TransactionTypeID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(gLEntity != null && gLEntity.GLEntityID != this.GLCostCentreEntityID)
                _gLCostCentreEntityIDProperty= gLEntity.GLEntityID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(bankTransaction != null && bankTransaction.BankTransactionID != this.BankTransactionID)
                _bankTransactionIDProperty= bankTransaction.BankTransactionID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(budget != null && budget.BudgetID != this.HouseBudgetID)
                _houseBudgetIDProperty= budget.BudgetID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(budget != null && budget.BudgetID != this.ClientBudgetID)
                _clientBudgetIDProperty= budget.BudgetID;

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
        ///    CSLA editable child business object of type <see cref="Gl"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_Gl_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(this.ClientBudgetID));
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
            Child_Update(applicationUser, null, null, null, null, connection,trans);
        }


        public void Child_Update(BankTransaction bankTransaction, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, bankTransaction, null, null, null, connection,trans);
        }


        public void Child_Update(Budget budget, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, null, budget, null, null, connection,trans);
        }


        public void Child_Update(GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, null, null, gLEntity, null, connection,trans);
        }


        public void Child_Update(TransactionType transactionType, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, null, null, null, transactionType, connection,trans);
        }

 
        public void Child_Update(ApplicationUser applicationUser, BankTransaction bankTransaction, Budget budget, GLEntity gLEntity, TransactionType transactionType, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(applicationUser, bankTransaction, budget, gLEntity, transactionType, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_Gl_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_GLID", this.Glid);
                command.Parameters.AddWithValue("@p_JournalDate", this.JournalDate);
                command.Parameters.AddWithValue("@p_PostingDate", ADOHelper.NullCheck(this.PostingDate));
                command.Parameters.AddWithValue("@p_GLAccountID", this.GLAccountID);
                command.Parameters.AddWithValue("@p_TransactionTypeID", transactionType != null ? transactionType.TransactionTypeID : this.TransactionTypeID);
                command.Parameters.AddWithValue("@p_GLCostCentreEntityID", ADOHelper.NullCheck(gLEntity != null ? gLEntity.GLEntityID : this.GLCostCentreEntityID));
                command.Parameters.AddWithValue("@p_BankTransactionID", ADOHelper.NullCheck(bankTransaction != null ? bankTransaction.BankTransactionID : this.BankTransactionID));
                command.Parameters.AddWithValue("@p_CategoryID", ADOHelper.NullCheck(this.CategoryID));
                command.Parameters.AddWithValue("@p_JournalNumber", this.JournalNumber);
                command.Parameters.AddWithValue("@p_Narration", this.Narration);
                command.Parameters.AddWithValue("@p_DocRef", this.DocRef);
                command.Parameters.AddWithValue("@p_CurrencyCode", this.CurrencyCode);
                command.Parameters.AddWithValue("@p_ExGstAMount", ADOHelper.NullCheck(this.ExGstAMount));
                command.Parameters.AddWithValue("@p_GSTAmount", ADOHelper.NullCheck(this.GSTAmount));
                command.Parameters.AddWithValue("@p_DRAmount", ADOHelper.NullCheck(this.DRAmount));
                command.Parameters.AddWithValue("@p_CRAmount", ADOHelper.NullCheck(this.CRAmount));
                command.Parameters.AddWithValue("@p_HouseBudgetID", ADOHelper.NullCheck(budget != null ? budget.BudgetID : this.HouseBudgetID));
                command.Parameters.AddWithValue("@p_ClientBudgetID", ADOHelper.NullCheck(budget != null ? budget.BudgetID : this.ClientBudgetID));
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
                if(transactionType != null && transactionType.TransactionTypeID != this.TransactionTypeID)
                    _transactionTypeIDProperty= transactionType.TransactionTypeID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(gLEntity != null && gLEntity.GLEntityID != this.GLCostCentreEntityID)
                    _gLCostCentreEntityIDProperty= gLEntity.GLEntityID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(bankTransaction != null && bankTransaction.BankTransactionID != this.BankTransactionID)
                    _bankTransactionIDProperty= bankTransaction.BankTransactionID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(budget != null && budget.BudgetID != this.HouseBudgetID)
                    _houseBudgetIDProperty= budget.BudgetID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(budget != null && budget.BudgetID != this.ClientBudgetID)
                    _clientBudgetIDProperty= budget.BudgetID;

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
        ///    CSLA editable child business object of type <see cref="Gl"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new GlCriteria (Glid), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  GlDTO dt=new GlDTO();
			dt.Glid =this.Glid ;
			dt.JournalDate =this.JournalDate ;
			dt.PostingDate =this.PostingDate ;
			dt.GLAccountID =this.GLAccountID ;
			dt.TransactionTypeID =this.TransactionTypeID ;
			dt.GLCostCentreEntityID =this.GLCostCentreEntityID ;
			dt.BankTransactionID =this.BankTransactionID ;
			dt.CategoryID =this.CategoryID ;
			dt.JournalNumber =this.JournalNumber ;
			dt.Narration =this.Narration ;
			dt.DocRef =this.DocRef ;
			dt.CurrencyCode =this.CurrencyCode ;
			dt.ExGstAMount =this.ExGstAMount ;
			dt.GSTAmount =this.GSTAmount ;
			dt.DRAmount =this.DRAmount ;
			dt.CRAmount =this.CRAmount ;
			dt.HouseBudgetID =this.HouseBudgetID ;
			dt.ClientBudgetID =this.ClientBudgetID ;
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
                LoadProperty(_glidProperty, reader["GLID"]);
                LoadProperty(_journalDateProperty, reader["JournalDate"]);
                LoadProperty(_postingDateProperty, reader["PostingDate"]);
                LoadProperty(_gLAccountIDProperty, reader["GLAccountID"]);
                LoadProperty(_transactionTypeIDProperty, reader["TransactionTypeID"]);
                LoadProperty(_gLCostCentreEntityIDProperty, reader["GLCostCentreEntityID"]);
                LoadProperty(_bankTransactionIDProperty, reader["BankTransactionID"]);
                LoadProperty(_categoryIDProperty, reader["CategoryID"]);
                LoadProperty(_journalNumberProperty, reader["JournalNumber"]);
                LoadProperty(_narrationProperty, reader["Narration"]);
                LoadProperty(_docRefProperty, reader["DocRef"]);
                LoadProperty(_currencyCodeProperty, reader["CurrencyCode"]);
                LoadProperty(_exGstAMountProperty, reader["ExGstAMount"]);
                LoadProperty(_gSTAmountProperty, reader["GSTAmount"]);
                LoadProperty(_dRAmountProperty, reader["DRAmount"]);
                LoadProperty(_cRAmountProperty, reader["CRAmount"]);
                LoadProperty(_houseBudgetIDProperty, reader["HouseBudgetID"]);
                LoadProperty(_clientBudgetIDProperty, reader["ClientBudgetID"]);
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
 