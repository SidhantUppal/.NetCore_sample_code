﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BudgetApproval.cs'.
//
//     Template path: DTO.Generated.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;


using System.Collections.Generic;
 
namespace CFMData
{
    [Serializable]
    public partial class BudgetApprovalDTO
    {
 #region Contructor(s)

        public BudgetApprovalDTO()
        { /* Require use of factory methods */ }

        #endregion

public BudgetApproval CopyDTO(BudgetApproval obj)
		{
			 
			obj.BudgetID =this.BudgetID ;
			obj.AdministratorUserID =this.AdministratorUserID ;
			obj.OperationsUserID =this.OperationsUserID ;
			obj.ApprovalDate =this.ApprovalDate ;
			obj.Status =this.Status ;
			obj.ReminderDate =this.ReminderDate ;
			obj.ApprovalFileID =this.ApprovalFileID ;
			obj.IsActive =this.IsActive ;
			return obj;
		}
        #region Properties

        public System.Int32 BudgetApprovalID { get; set; }
        public System.Int32 BudgetID { get; set; }
        public System.Int32? AdministratorUserID { get; set; }
        public System.Int32? OperationsUserID { get; set; }
        public System.DateTime? ApprovalDate { get; set; }
        public System.String Status { get; set; }
        public System.DateTime? ReminderDate { get; set; }
        public System.Int32? ApprovalFileID { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Int32? UpdatedBy { get; set; }
        public System.DateTime? UpdatedOn { get; set; }

	
	
	
	
	
	
        private ApplicationUserDTO  _createdByApplicationUserProperty=null;
        public ApplicationUserDTO CreatedByApplicationUser
        {
			get
			{
				return  _createdByApplicationUserProperty;
			}
			set
			{
				 _createdByApplicationUserProperty=value;
			}
			
		}
        public void LoadCreatedByApplicationUser(BudgetApproval obj)
		{
			if(obj.CreatedByApplicationUser!=null)
			{
				_createdByApplicationUserProperty=obj.CreatedByApplicationUser.CurrentDTO;
			}
		}
		
		
        private ApplicationUserDTO  _administratorUserApplicationUserProperty=null;
        public ApplicationUserDTO AdministratorUserApplicationUser
        {
			get
			{
				return  _administratorUserApplicationUserProperty;
			}
			set
			{
				 _administratorUserApplicationUserProperty=value;
			}
			
		}
        public void LoadAdministratorUserApplicationUser(BudgetApproval obj)
		{
			if(obj.AdministratorUserApplicationUser!=null)
			{
				_administratorUserApplicationUserProperty=obj.AdministratorUserApplicationUser.CurrentDTO;
			}
		}
		
		
        private ApplicationUserDTO  _operationsUserApplicationUserProperty=null;
        public ApplicationUserDTO OperationsUserApplicationUser
        {
			get
			{
				return  _operationsUserApplicationUserProperty;
			}
			set
			{
				 _operationsUserApplicationUserProperty=value;
			}
			
		}
        public void LoadOperationsUserApplicationUser(BudgetApproval obj)
		{
			if(obj.OperationsUserApplicationUser!=null)
			{
				_operationsUserApplicationUserProperty=obj.OperationsUserApplicationUser.CurrentDTO;
			}
		}
		
		
        private BudgetDTO  _budgetProperty=null;
        public BudgetDTO Budget
        {
			get
			{
				return  _budgetProperty;
			}
			set
			{
				 _budgetProperty=value;
			}
			
		}
        public void LoadBudget(BudgetApproval obj)
		{
			if(obj.Budget!=null)
			{
				_budgetProperty=obj.Budget.CurrentDTO;
			}
		}
		
		
        private ApplicationUserDTO  _updatedByApplicationUserProperty=null;
        public ApplicationUserDTO UpdatedByApplicationUser
        {
			get
			{
				return  _updatedByApplicationUserProperty;
			}
			set
			{
				 _updatedByApplicationUserProperty=value;
			}
			
		}
        public void LoadUpdatedByApplicationUser(BudgetApproval obj)
		{
			if(obj.UpdatedByApplicationUser!=null)
			{
				_updatedByApplicationUserProperty=obj.UpdatedByApplicationUser.CurrentDTO;
			}
		}
		
		
			



        #endregion

    }
}