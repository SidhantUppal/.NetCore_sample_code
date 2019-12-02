﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'HomeClient.cs'.
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
    public partial class HomeClientDTO
    {
 #region Contructor(s)

        public HomeClientDTO()
        { /* Require use of factory methods */ }

        #endregion

public HomeClient CopyDTO(HomeClient obj)
		{
			 
			obj.HomeID =this.HomeID ;
			obj.ClientID =this.ClientID ;
			obj.EntryDate =this.EntryDate ;
			obj.ExitDate =this.ExitDate ;
			obj.IsActive =this.IsActive ;
			return obj;
		}
        #region Properties

        public System.Int32 HomeClientID { get; set; }
        public System.Int32 HomeID { get; set; }
        public System.Int32 ClientID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.DateTime? ExitDate { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Int32? UpdatedBy { get; set; }
        public System.DateTime? UpdatedOn { get; set; }

	// OneToMany
        public void LoadBudgetClientAdjustments(HomeClient obj)
        {
			if(obj.BudgetClientAdjustments!=null)
			{
				_budgetClientAdjustmentsProperty=obj.BudgetClientAdjustments.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetClientAdjustmentDTO>  _budgetClientAdjustmentsProperty=new List<BudgetClientAdjustmentDTO>();
        public List<BudgetClientAdjustmentDTO> BudgetClientAdjustments
        {
			get
			{
				return  _budgetClientAdjustmentsProperty;
			}
			
		}
	
	
	
	
	
	
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
        public void LoadCreatedByApplicationUser(HomeClient obj)
		{
			if(obj.CreatedByApplicationUser!=null)
			{
				_createdByApplicationUserProperty=obj.CreatedByApplicationUser.CurrentDTO;
			}
		}
		
		
        private ClientDTO  _clientProperty=null;
        public ClientDTO Client
        {
			get
			{
				return  _clientProperty;
			}
			set
			{
				 _clientProperty=value;
			}
			
		}
        public void LoadClient(HomeClient obj)
		{
			if(obj.Client!=null)
			{
				_clientProperty=obj.Client.CurrentDTO;
			}
		}
		
		
        private HomeDTO  _homeProperty=null;
        public HomeDTO Home
        {
			get
			{
				return  _homeProperty;
			}
			set
			{
				 _homeProperty=value;
			}
			
		}
        public void LoadHome(HomeClient obj)
		{
			if(obj.Home!=null)
			{
				_homeProperty=obj.Home.CurrentDTO;
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
        public void LoadUpdatedByApplicationUser(HomeClient obj)
		{
			if(obj.UpdatedByApplicationUser!=null)
			{
				_updatedByApplicationUserProperty=obj.UpdatedByApplicationUser.CurrentDTO;
			}
		}
		
		
			



        #endregion

    }
}