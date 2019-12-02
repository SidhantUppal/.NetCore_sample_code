﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BudgetLineList.cs'.
//
//     Template: EditableRootList.DataAccess.StoredProcedures.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace CFMData
{
    public partial class BudgetLineList
    {
        
        private BudgetLineList DataPortal_Fetch(BudgetLineCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return null;

            //RaiseListChangedEvents = false;

            // Fetch Child objects.
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_BudgetLine_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
		
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_FortnightAmountHasValue", criteria.FortnightAmountHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
                    using(var reader = command.ExecuteReader())
                    {
						
                        if(reader.Read())
                        {
                           var rowParser = reader.GetRowParser<CFMData.BudgetLine>();
                           do
                           {
								
                              this.Add(CFMData.BudgetLine.GetBudgetLine(rowParser, reader));
                           }while(reader.Read());
                        }
						OnFetched();
                        return this;
                    }
                }
            }

            //RaiseListChangedEvents = true;

            
        }

        //[Transactional(TransactionalTypes.TransactionScope)]
        protected   void DataPortal_Update()
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

          

           

            for (int index = 0; index < this.Count; index++)
            {
                this[index] = this[index].Save();
            }

           

            OnUpdated();
         }
    }
}
