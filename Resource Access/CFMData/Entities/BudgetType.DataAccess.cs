﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BudgetType.cs'.
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
	public partial class BudgetType
	{
    
		private BudgetType DataPortal_Fetch(BudgetTypeCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_BudgetType_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<BudgetType>();                       
						if(reader.Read())
						{
							return GetBudgetType(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.BudgetType' using the following criteria: {0}.", criteria));
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
				
				using(var command = new SqlCommand("[dbo].[spCFM_BudgetType_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_BudgetTypeID", this.BudgetTypeID);
                command.Parameters.AddWithValue("@p_Code", this.Code);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
					command.ExecuteNonQuery();                  
                    
				}
                
				_originalBudgetTypeIDProperty= this.BudgetTypeID;
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
            if(OriginalBudgetTypeID != BudgetTypeID)
            {
                // Insert new child.
				BudgetType item = new BudgetType {BudgetTypeID = BudgetTypeID, Code = Code, Name = Name};
				
				item.DataPortal_Update();

                // Mark editable child lists as dirty. This code may need to be updated to one-to-one relationships.
				foreach(Budget itemToUpdate in Budgets)
				{
                itemToUpdate.BudgetTypeID = BudgetTypeID;
				}

				// Create a new connection.
				using (var connection = new SqlConnection(ADOHelper.ConnectionString))
				{
					connection.Open();
					SqlTransaction trans = connection.BeginTransaction();
					try
					{
						UpdateChildren(this, connection,trans);
						trans.Commit();
					}
					catch(Exception ex)
					{
						trans.Rollback();
						throw;
					}
					
					//FieldManager.UpdateChildren(this, connection);
				}
				// Delete the old.
				var criteria = new BudgetTypeCriteria {BudgetTypeID = OriginalBudgetTypeID};
				
				DataPortal_Delete(criteria);

				// Mark the original as the new one.
				OriginalBudgetTypeID = BudgetTypeID;
				OnUpdated();

				return;
			}

			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				using(var command = new SqlCommand("[dbo].[spCFM_BudgetType_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_OriginalBudgetTypeID", this.OriginalBudgetTypeID);
                command.Parameters.AddWithValue("@p_BudgetTypeID", this.BudgetTypeID);
                command.Parameters.AddWithValue("@p_Code", this.Code);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
					int result = command.ExecuteNonQuery();
					if (result == 0)
						throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

					_originalBudgetTypeIDProperty= this.BudgetTypeID;
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
		protected   void UpdateChildren(BudgetType parent,SqlConnection connection,SqlTransaction trans)
		{
		
		
			
			if(_budgetsPropertyChecked )
			{
				if(_budgetsProperty!=null)
				{
				
					foreach (Budget obj in _budgetsProperty)
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
			DataPortal_Delete(new BudgetTypeCriteria (BudgetTypeID));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(BudgetTypeCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_BudgetType_Delete]", connection))
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
        ///    CSLA editable child business object of type <see cref="BudgetType"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BudgetType_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BudgetTypeID", this.BudgetTypeID);
                command.Parameters.AddWithValue("@p_Code", this.Code);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));

                command.ExecuteNonQuery();

                // Update the original non-identity primary key value.
                _originalBudgetTypeIDProperty= this.BudgetTypeID;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        #endregion

        #region Child_Update

        /// <summary>
        /// Updates the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="BudgetType"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BudgetType_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_OriginalBudgetTypeID", this.OriginalBudgetTypeID);
                command.Parameters.AddWithValue("@p_BudgetTypeID", this.BudgetTypeID);
                command.Parameters.AddWithValue("@p_Code", this.Code);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update non-identity primary key value.
                _budgetTypeIDProperty=(System.Int32)command.Parameters["@p_BudgetTypeID"].Value;

                // Update non-identity primary key value.
                _originalBudgetTypeIDProperty= this.BudgetTypeID;
            }

            UpdateChildren(this, connection,trans);

            OnChildUpdated();
        }
        #endregion

        /// <summary>
        /// Deletes the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="BudgetType"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new BudgetTypeCriteria (BudgetTypeID), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  BudgetTypeDTO dt=new BudgetTypeDTO();
			dt.BudgetTypeID =this.BudgetTypeID ;
			dt.Code =this.Code ;
			dt.Name =this.Name ;
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
                LoadProperty(_budgetTypeIDProperty, reader["BudgetTypeID"]);
                LoadProperty(_originalBudgetTypeIDProperty, reader["BudgetTypeID"]);
                LoadProperty(_codeProperty, reader["Code"]);
                LoadProperty(_nameProperty, reader["Name"]);
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
 