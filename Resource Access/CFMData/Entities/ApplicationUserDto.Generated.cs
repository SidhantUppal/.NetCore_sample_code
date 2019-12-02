﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'ApplicationUser.cs'.
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
    public partial class ApplicationUserDTO
    {
 #region Contructor(s)

        public ApplicationUserDTO()
        { /* Require use of factory methods */ }

        #endregion

public ApplicationUser CopyDTO(ApplicationUser obj)
		{
			 
			obj.LoginName =this.LoginName ;
			obj.Password =this.Password ;
			obj.FirstName =this.FirstName ;
			obj.LastName =this.LastName ;
			obj.EmailAddress =this.EmailAddress ;
			obj.MobilePhone =this.MobilePhone ;
			obj.WorkPhone =this.WorkPhone ;
			obj.EmployeeNumber =this.EmployeeNumber ;
			obj.IsActive =this.IsActive ;
			obj.PasswordResetNeeded =this.PasswordResetNeeded ;
			obj.PasswordResetToken =this.PasswordResetToken ;
			obj.PasswordResetTokenExpiry =this.PasswordResetTokenExpiry ;
			obj.MustChangePassword =this.MustChangePassword ;
			obj.ApplicationRoleID =this.ApplicationRoleID ;
			obj.LastLoggedOn =this.LastLoggedOn ;
			obj.StatementDeliveryOptionID =this.StatementDeliveryOptionID ;
			obj.PhysicalAddressID =this.PhysicalAddressID ;
			obj.SameAsPhysicalAddress =this.SameAsPhysicalAddress ;
			obj.PostalAddressID =this.PostalAddressID ;
			obj.LastActiveCheckSentOn =this.LastActiveCheckSentOn ;
			obj.LastPasswordChangedOn =this.LastPasswordChangedOn ;
			return obj;
		}
        #region Properties

        public System.Int32 ApplicationUserID { get; set; }
        public System.String LoginName { get; set; }
        public System.String Password { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String EmailAddress { get; set; }
        public System.String MobilePhone { get; set; }
        public System.String WorkPhone { get; set; }
        public System.String EmployeeNumber { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Boolean PasswordResetNeeded { get; set; }
        public System.String PasswordResetToken { get; set; }
        public System.DateTime? PasswordResetTokenExpiry { get; set; }
        public System.Boolean MustChangePassword { get; set; }
        public System.Int32? ApplicationRoleID { get; set; }
        public System.DateTime? LastLoggedOn { get; set; }
        public System.Int32? StatementDeliveryOptionID { get; set; }
        public System.Int32? PhysicalAddressID { get; set; }
        public System.Boolean SameAsPhysicalAddress { get; set; }
        public System.Int32? PostalAddressID { get; set; }
        public System.DateTime? LastActiveCheckSentOn { get; set; }
        public System.Int32? CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Int32? UpdatedBy { get; set; }
        public System.DateTime? UpdatedOn { get; set; }
        public System.DateTime? LastPasswordChangedOn { get; set; }

	// OneToMany
        public void LoadCreatedByAddresses(ApplicationUser obj)
        {
			if(obj.CreatedByAddresses!=null)
			{
				_createdByAddressesProperty=obj.CreatedByAddresses.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<AddressDTO>  _createdByAddressesProperty=new List<AddressDTO>();
        public List<AddressDTO> CreatedByAddresses
        {
			get
			{
				return  _createdByAddressesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByAddresses(ApplicationUser obj)
        {
			if(obj.UpdatedByAddresses!=null)
			{
				_updatedByAddressesProperty=obj.UpdatedByAddresses.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<AddressDTO>  _updatedByAddressesProperty=new List<AddressDTO>();
        public List<AddressDTO> UpdatedByAddresses
        {
			get
			{
				return  _updatedByAddressesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByApplicationPermissions(ApplicationUser obj)
        {
			if(obj.CreatedByApplicationPermissions!=null)
			{
				_createdByApplicationPermissionsProperty=obj.CreatedByApplicationPermissions.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<ApplicationPermissionDTO>  _createdByApplicationPermissionsProperty=new List<ApplicationPermissionDTO>();
        public List<ApplicationPermissionDTO> CreatedByApplicationPermissions
        {
			get
			{
				return  _createdByApplicationPermissionsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByApplicationPermissions(ApplicationUser obj)
        {
			if(obj.UpdatedByApplicationPermissions!=null)
			{
				_updatedByApplicationPermissionsProperty=obj.UpdatedByApplicationPermissions.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<ApplicationPermissionDTO>  _updatedByApplicationPermissionsProperty=new List<ApplicationPermissionDTO>();
        public List<ApplicationPermissionDTO> UpdatedByApplicationPermissions
        {
			get
			{
				return  _updatedByApplicationPermissionsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByApplicationRoles(ApplicationUser obj)
        {
			if(obj.CreatedByApplicationRoles!=null)
			{
				_createdByApplicationRolesProperty=obj.CreatedByApplicationRoles.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<ApplicationRoleDTO>  _createdByApplicationRolesProperty=new List<ApplicationRoleDTO>();
        public List<ApplicationRoleDTO> CreatedByApplicationRoles
        {
			get
			{
				return  _createdByApplicationRolesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByApplicationRoles(ApplicationUser obj)
        {
			if(obj.UpdatedByApplicationRoles!=null)
			{
				_updatedByApplicationRolesProperty=obj.UpdatedByApplicationRoles.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<ApplicationRoleDTO>  _updatedByApplicationRolesProperty=new List<ApplicationRoleDTO>();
        public List<ApplicationRoleDTO> UpdatedByApplicationRoles
        {
			get
			{
				return  _updatedByApplicationRolesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByApplicationUsers1(ApplicationUser obj)
        {
			if(obj.UpdatedByApplicationUsers1!=null)
			{
				_updatedByApplicationUsers1Property=obj.UpdatedByApplicationUsers1.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<ApplicationUserDTO>  _updatedByApplicationUsers1Property=new List<ApplicationUserDTO>();
        public List<ApplicationUserDTO> UpdatedByApplicationUsers1
        {
			get
			{
				return  _updatedByApplicationUsers1Property;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByApplicationUsers2(ApplicationUser obj)
        {
			if(obj.UpdatedByApplicationUsers2!=null)
			{
				_updatedByApplicationUsers2Property=obj.UpdatedByApplicationUsers2.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<ApplicationUserDTO>  _updatedByApplicationUsers2Property=new List<ApplicationUserDTO>();
        public List<ApplicationUserDTO> UpdatedByApplicationUsers2
        {
			get
			{
				return  _updatedByApplicationUsers2Property;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBankAccounts(ApplicationUser obj)
        {
			if(obj.CreatedByBankAccounts!=null)
			{
				_createdByBankAccountsProperty=obj.CreatedByBankAccounts.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BankAccountDTO>  _createdByBankAccountsProperty=new List<BankAccountDTO>();
        public List<BankAccountDTO> CreatedByBankAccounts
        {
			get
			{
				return  _createdByBankAccountsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBankAccounts(ApplicationUser obj)
        {
			if(obj.UpdatedByBankAccounts!=null)
			{
				_updatedByBankAccountsProperty=obj.UpdatedByBankAccounts.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BankAccountDTO>  _updatedByBankAccountsProperty=new List<BankAccountDTO>();
        public List<BankAccountDTO> UpdatedByBankAccounts
        {
			get
			{
				return  _updatedByBankAccountsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBankAccountCards(ApplicationUser obj)
        {
			if(obj.CreatedByBankAccountCards!=null)
			{
				_createdByBankAccountCardsProperty=obj.CreatedByBankAccountCards.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BankAccountCardDTO>  _createdByBankAccountCardsProperty=new List<BankAccountCardDTO>();
        public List<BankAccountCardDTO> CreatedByBankAccountCards
        {
			get
			{
				return  _createdByBankAccountCardsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadHeldByStaffBankAccountCards(ApplicationUser obj)
        {
			if(obj.HeldByStaffBankAccountCards!=null)
			{
				_heldByStaffBankAccountCardsProperty=obj.HeldByStaffBankAccountCards.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BankAccountCardDTO>  _heldByStaffBankAccountCardsProperty=new List<BankAccountCardDTO>();
        public List<BankAccountCardDTO> HeldByStaffBankAccountCards
        {
			get
			{
				return  _heldByStaffBankAccountCardsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBankAccountCards(ApplicationUser obj)
        {
			if(obj.UpdatedByBankAccountCards!=null)
			{
				_updatedByBankAccountCardsProperty=obj.UpdatedByBankAccountCards.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BankAccountCardDTO>  _updatedByBankAccountCardsProperty=new List<BankAccountCardDTO>();
        public List<BankAccountCardDTO> UpdatedByBankAccountCards
        {
			get
			{
				return  _updatedByBankAccountCardsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBankTransactions(ApplicationUser obj)
        {
			if(obj.CreatedByBankTransactions!=null)
			{
				_createdByBankTransactionsProperty=obj.CreatedByBankTransactions.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BankTransactionDTO>  _createdByBankTransactionsProperty=new List<BankTransactionDTO>();
        public List<BankTransactionDTO> CreatedByBankTransactions
        {
			get
			{
				return  _createdByBankTransactionsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBankTransactions(ApplicationUser obj)
        {
			if(obj.UpdatedByBankTransactions!=null)
			{
				_updatedByBankTransactionsProperty=obj.UpdatedByBankTransactions.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BankTransactionDTO>  _updatedByBankTransactionsProperty=new List<BankTransactionDTO>();
        public List<BankTransactionDTO> UpdatedByBankTransactions
        {
			get
			{
				return  _updatedByBankTransactionsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBudgets(ApplicationUser obj)
        {
			if(obj.CreatedByBudgets!=null)
			{
				_createdByBudgetsProperty=obj.CreatedByBudgets.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetDTO>  _createdByBudgetsProperty=new List<BudgetDTO>();
        public List<BudgetDTO> CreatedByBudgets
        {
			get
			{
				return  _createdByBudgetsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBudgets(ApplicationUser obj)
        {
			if(obj.UpdatedByBudgets!=null)
			{
				_updatedByBudgetsProperty=obj.UpdatedByBudgets.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetDTO>  _updatedByBudgetsProperty=new List<BudgetDTO>();
        public List<BudgetDTO> UpdatedByBudgets
        {
			get
			{
				return  _updatedByBudgetsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBudgetApprovals(ApplicationUser obj)
        {
			if(obj.CreatedByBudgetApprovals!=null)
			{
				_createdByBudgetApprovalsProperty=obj.CreatedByBudgetApprovals.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetApprovalDTO>  _createdByBudgetApprovalsProperty=new List<BudgetApprovalDTO>();
        public List<BudgetApprovalDTO> CreatedByBudgetApprovals
        {
			get
			{
				return  _createdByBudgetApprovalsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadAdministratorUserBudgetApprovals(ApplicationUser obj)
        {
			if(obj.AdministratorUserBudgetApprovals!=null)
			{
				_administratorUserBudgetApprovalsProperty=obj.AdministratorUserBudgetApprovals.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetApprovalDTO>  _administratorUserBudgetApprovalsProperty=new List<BudgetApprovalDTO>();
        public List<BudgetApprovalDTO> AdministratorUserBudgetApprovals
        {
			get
			{
				return  _administratorUserBudgetApprovalsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadOperationsUserBudgetApprovals(ApplicationUser obj)
        {
			if(obj.OperationsUserBudgetApprovals!=null)
			{
				_operationsUserBudgetApprovalsProperty=obj.OperationsUserBudgetApprovals.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetApprovalDTO>  _operationsUserBudgetApprovalsProperty=new List<BudgetApprovalDTO>();
        public List<BudgetApprovalDTO> OperationsUserBudgetApprovals
        {
			get
			{
				return  _operationsUserBudgetApprovalsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBudgetApprovals(ApplicationUser obj)
        {
			if(obj.UpdatedByBudgetApprovals!=null)
			{
				_updatedByBudgetApprovalsProperty=obj.UpdatedByBudgetApprovals.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetApprovalDTO>  _updatedByBudgetApprovalsProperty=new List<BudgetApprovalDTO>();
        public List<BudgetApprovalDTO> UpdatedByBudgetApprovals
        {
			get
			{
				return  _updatedByBudgetApprovalsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBudgetApprovalComms(ApplicationUser obj)
        {
			if(obj.CreatedByBudgetApprovalComms!=null)
			{
				_createdByBudgetApprovalCommsProperty=obj.CreatedByBudgetApprovalComms.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetApprovalCommDTO>  _createdByBudgetApprovalCommsProperty=new List<BudgetApprovalCommDTO>();
        public List<BudgetApprovalCommDTO> CreatedByBudgetApprovalComms
        {
			get
			{
				return  _createdByBudgetApprovalCommsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBudgetApprovalComms(ApplicationUser obj)
        {
			if(obj.UpdatedByBudgetApprovalComms!=null)
			{
				_updatedByBudgetApprovalCommsProperty=obj.UpdatedByBudgetApprovalComms.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetApprovalCommDTO>  _updatedByBudgetApprovalCommsProperty=new List<BudgetApprovalCommDTO>();
        public List<BudgetApprovalCommDTO> UpdatedByBudgetApprovalComms
        {
			get
			{
				return  _updatedByBudgetApprovalCommsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBudgetLines(ApplicationUser obj)
        {
			if(obj.CreatedByBudgetLines!=null)
			{
				_createdByBudgetLinesProperty=obj.CreatedByBudgetLines.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetLineDTO>  _createdByBudgetLinesProperty=new List<BudgetLineDTO>();
        public List<BudgetLineDTO> CreatedByBudgetLines
        {
			get
			{
				return  _createdByBudgetLinesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBudgetLines(ApplicationUser obj)
        {
			if(obj.UpdatedByBudgetLines!=null)
			{
				_updatedByBudgetLinesProperty=obj.UpdatedByBudgetLines.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetLineDTO>  _updatedByBudgetLinesProperty=new List<BudgetLineDTO>();
        public List<BudgetLineDTO> UpdatedByBudgetLines
        {
			get
			{
				return  _updatedByBudgetLinesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByBudgetLineCategories(ApplicationUser obj)
        {
			if(obj.CreatedByBudgetLineCategories!=null)
			{
				_createdByBudgetLineCategoriesProperty=obj.CreatedByBudgetLineCategories.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<BudgetLineCategoryDTO>  _createdByBudgetLineCategoriesProperty=new List<BudgetLineCategoryDTO>();
        public List<BudgetLineCategoryDTO> CreatedByBudgetLineCategories
        {
			get
			{
				return  _createdByBudgetLineCategoriesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByBudgetLineCategories(ApplicationUser obj)
        {
			if(obj.UpdatedByBudgetLineCategories!=null)
			{
				_updatedByBudgetLineCategoriesProperty=obj.UpdatedByBudgetLineCategories.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<BudgetLineCategoryDTO>  _updatedByBudgetLineCategoriesProperty=new List<BudgetLineCategoryDTO>();
        public List<BudgetLineCategoryDTO> UpdatedByBudgetLineCategories
        {
			get
			{
				return  _updatedByBudgetLineCategoriesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByClients(ApplicationUser obj)
        {
			if(obj.CreatedByClients!=null)
			{
				_createdByClientsProperty=obj.CreatedByClients.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<ClientDTO>  _createdByClientsProperty=new List<ClientDTO>();
        public List<ClientDTO> CreatedByClients
        {
			get
			{
				return  _createdByClientsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByClients(ApplicationUser obj)
        {
			if(obj.UpdatedByClients!=null)
			{
				_updatedByClientsProperty=obj.UpdatedByClients.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<ClientDTO>  _updatedByClientsProperty=new List<ClientDTO>();
        public List<ClientDTO> UpdatedByClients
        {
			get
			{
				return  _updatedByClientsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByDataOptions(ApplicationUser obj)
        {
			if(obj.CreatedByDataOptions!=null)
			{
				_createdByDataOptionsProperty=obj.CreatedByDataOptions.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<DataOptionDTO>  _createdByDataOptionsProperty=new List<DataOptionDTO>();
        public List<DataOptionDTO> CreatedByDataOptions
        {
			get
			{
				return  _createdByDataOptionsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByDataOptions(ApplicationUser obj)
        {
			if(obj.UpdatedByDataOptions!=null)
			{
				_updatedByDataOptionsProperty=obj.UpdatedByDataOptions.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<DataOptionDTO>  _updatedByDataOptionsProperty=new List<DataOptionDTO>();
        public List<DataOptionDTO> UpdatedByDataOptions
        {
			get
			{
				return  _updatedByDataOptionsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByDataOptionTypes(ApplicationUser obj)
        {
			if(obj.CreatedByDataOptionTypes!=null)
			{
				_createdByDataOptionTypesProperty=obj.CreatedByDataOptionTypes.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<DataOptionTypeDTO>  _createdByDataOptionTypesProperty=new List<DataOptionTypeDTO>();
        public List<DataOptionTypeDTO> CreatedByDataOptionTypes
        {
			get
			{
				return  _createdByDataOptionTypesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByDataOptionTypes(ApplicationUser obj)
        {
			if(obj.UpdatedByDataOptionTypes!=null)
			{
				_updatedByDataOptionTypesProperty=obj.UpdatedByDataOptionTypes.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<DataOptionTypeDTO>  _updatedByDataOptionTypesProperty=new List<DataOptionTypeDTO>();
        public List<DataOptionTypeDTO> UpdatedByDataOptionTypes
        {
			get
			{
				return  _updatedByDataOptionTypesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByFinAdministrators(ApplicationUser obj)
        {
			if(obj.CreatedByFinAdministrators!=null)
			{
				_createdByFinAdministratorsProperty=obj.CreatedByFinAdministrators.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<FinAdministratorDTO>  _createdByFinAdministratorsProperty=new List<FinAdministratorDTO>();
        public List<FinAdministratorDTO> CreatedByFinAdministrators
        {
			get
			{
				return  _createdByFinAdministratorsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByFinAdministrators(ApplicationUser obj)
        {
			if(obj.UpdatedByFinAdministrators!=null)
			{
				_updatedByFinAdministratorsProperty=obj.UpdatedByFinAdministrators.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<FinAdministratorDTO>  _updatedByFinAdministratorsProperty=new List<FinAdministratorDTO>();
        public List<FinAdministratorDTO> UpdatedByFinAdministrators
        {
			get
			{
				return  _updatedByFinAdministratorsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByFinAdministratorAppUsers(ApplicationUser obj)
        {
			if(obj.CreatedByFinAdministratorAppUsers!=null)
			{
				_createdByFinAdministratorAppUsersProperty=obj.CreatedByFinAdministratorAppUsers.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<FinAdministratorAppUserDTO>  _createdByFinAdministratorAppUsersProperty=new List<FinAdministratorAppUserDTO>();
        public List<FinAdministratorAppUserDTO> CreatedByFinAdministratorAppUsers
        {
			get
			{
				return  _createdByFinAdministratorAppUsersProperty;
			}
			
		}
	// OneToMany
        public void LoadApplicationUserFinAdministratorAppUsers(ApplicationUser obj)
        {
			if(obj.ApplicationUserFinAdministratorAppUsers!=null)
			{
				_applicationUserFinAdministratorAppUsersProperty=obj.ApplicationUserFinAdministratorAppUsers.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<FinAdministratorAppUserDTO>  _applicationUserFinAdministratorAppUsersProperty=new List<FinAdministratorAppUserDTO>();
        public List<FinAdministratorAppUserDTO> ApplicationUserFinAdministratorAppUsers
        {
			get
			{
				return  _applicationUserFinAdministratorAppUsersProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByFinAdministratorAppUsers(ApplicationUser obj)
        {
			if(obj.UpdatedByFinAdministratorAppUsers!=null)
			{
				_updatedByFinAdministratorAppUsersProperty=obj.UpdatedByFinAdministratorAppUsers.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<FinAdministratorAppUserDTO>  _updatedByFinAdministratorAppUsersProperty=new List<FinAdministratorAppUserDTO>();
        public List<FinAdministratorAppUserDTO> UpdatedByFinAdministratorAppUsers
        {
			get
			{
				return  _updatedByFinAdministratorAppUsersProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByFinAdministratorClients(ApplicationUser obj)
        {
			if(obj.CreatedByFinAdministratorClients!=null)
			{
				_createdByFinAdministratorClientsProperty=obj.CreatedByFinAdministratorClients.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<FinAdministratorClientDTO>  _createdByFinAdministratorClientsProperty=new List<FinAdministratorClientDTO>();
        public List<FinAdministratorClientDTO> CreatedByFinAdministratorClients
        {
			get
			{
				return  _createdByFinAdministratorClientsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByFinAdministratorClients(ApplicationUser obj)
        {
			if(obj.UpdatedByFinAdministratorClients!=null)
			{
				_updatedByFinAdministratorClientsProperty=obj.UpdatedByFinAdministratorClients.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<FinAdministratorClientDTO>  _updatedByFinAdministratorClientsProperty=new List<FinAdministratorClientDTO>();
        public List<FinAdministratorClientDTO> UpdatedByFinAdministratorClients
        {
			get
			{
				return  _updatedByFinAdministratorClientsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByGls(ApplicationUser obj)
        {
			if(obj.CreatedByGls!=null)
			{
				_createdByGlsProperty=obj.CreatedByGls.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<GlDTO>  _createdByGlsProperty=new List<GlDTO>();
        public List<GlDTO> CreatedByGls
        {
			get
			{
				return  _createdByGlsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByGls(ApplicationUser obj)
        {
			if(obj.UpdatedByGls!=null)
			{
				_updatedByGlsProperty=obj.UpdatedByGls.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<GlDTO>  _updatedByGlsProperty=new List<GlDTO>();
        public List<GlDTO> UpdatedByGls
        {
			get
			{
				return  _updatedByGlsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByGLAccounts(ApplicationUser obj)
        {
			if(obj.CreatedByGLAccounts!=null)
			{
				_createdByGLAccountsProperty=obj.CreatedByGLAccounts.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<GLAccountDTO>  _createdByGLAccountsProperty=new List<GLAccountDTO>();
        public List<GLAccountDTO> CreatedByGLAccounts
        {
			get
			{
				return  _createdByGLAccountsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByGLAccounts(ApplicationUser obj)
        {
			if(obj.UpdatedByGLAccounts!=null)
			{
				_updatedByGLAccountsProperty=obj.UpdatedByGLAccounts.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<GLAccountDTO>  _updatedByGLAccountsProperty=new List<GLAccountDTO>();
        public List<GLAccountDTO> UpdatedByGLAccounts
        {
			get
			{
				return  _updatedByGLAccountsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByGLAccountTypes(ApplicationUser obj)
        {
			if(obj.CreatedByGLAccountTypes!=null)
			{
				_createdByGLAccountTypesProperty=obj.CreatedByGLAccountTypes.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<GLAccountTypeDTO>  _createdByGLAccountTypesProperty=new List<GLAccountTypeDTO>();
        public List<GLAccountTypeDTO> CreatedByGLAccountTypes
        {
			get
			{
				return  _createdByGLAccountTypesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByGLAccountTypes(ApplicationUser obj)
        {
			if(obj.UpdatedByGLAccountTypes!=null)
			{
				_updatedByGLAccountTypesProperty=obj.UpdatedByGLAccountTypes.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<GLAccountTypeDTO>  _updatedByGLAccountTypesProperty=new List<GLAccountTypeDTO>();
        public List<GLAccountTypeDTO> UpdatedByGLAccountTypes
        {
			get
			{
				return  _updatedByGLAccountTypesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByGLEntities(ApplicationUser obj)
        {
			if(obj.CreatedByGLEntities!=null)
			{
				_createdByGLEntitiesProperty=obj.CreatedByGLEntities.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<GLEntityDTO>  _createdByGLEntitiesProperty=new List<GLEntityDTO>();
        public List<GLEntityDTO> CreatedByGLEntities
        {
			get
			{
				return  _createdByGLEntitiesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByGLEntities(ApplicationUser obj)
        {
			if(obj.UpdatedByGLEntities!=null)
			{
				_updatedByGLEntitiesProperty=obj.UpdatedByGLEntities.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<GLEntityDTO>  _updatedByGLEntitiesProperty=new List<GLEntityDTO>();
        public List<GLEntityDTO> UpdatedByGLEntities
        {
			get
			{
				return  _updatedByGLEntitiesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByHomes(ApplicationUser obj)
        {
			if(obj.CreatedByHomes!=null)
			{
				_createdByHomesProperty=obj.CreatedByHomes.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<HomeDTO>  _createdByHomesProperty=new List<HomeDTO>();
        public List<HomeDTO> CreatedByHomes
        {
			get
			{
				return  _createdByHomesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByHomes(ApplicationUser obj)
        {
			if(obj.UpdatedByHomes!=null)
			{
				_updatedByHomesProperty=obj.UpdatedByHomes.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<HomeDTO>  _updatedByHomesProperty=new List<HomeDTO>();
        public List<HomeDTO> UpdatedByHomes
        {
			get
			{
				return  _updatedByHomesProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByHomeClients(ApplicationUser obj)
        {
			if(obj.CreatedByHomeClients!=null)
			{
				_createdByHomeClientsProperty=obj.CreatedByHomeClients.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<HomeClientDTO>  _createdByHomeClientsProperty=new List<HomeClientDTO>();
        public List<HomeClientDTO> CreatedByHomeClients
        {
			get
			{
				return  _createdByHomeClientsProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByHomeClients(ApplicationUser obj)
        {
			if(obj.UpdatedByHomeClients!=null)
			{
				_updatedByHomeClientsProperty=obj.UpdatedByHomeClients.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<HomeClientDTO>  _updatedByHomeClientsProperty=new List<HomeClientDTO>();
        public List<HomeClientDTO> UpdatedByHomeClients
        {
			get
			{
				return  _updatedByHomeClientsProperty;
			}
			
		}
	// OneToMany
        public void LoadCreatedByMailingTemplates(ApplicationUser obj)
        {
			if(obj.CreatedByMailingTemplates!=null)
			{
				_createdByMailingTemplatesProperty=obj.CreatedByMailingTemplates.CurrentDTO;
			}
        }
	// OneToMany
	
        private List<MailingTemplateDTO>  _createdByMailingTemplatesProperty=new List<MailingTemplateDTO>();
        public List<MailingTemplateDTO> CreatedByMailingTemplates
        {
			get
			{
				return  _createdByMailingTemplatesProperty;
			}
			
		}
	// ZeroOrOneToMany
        public void LoadUpdatedByMailingTemplates(ApplicationUser obj)
        {
			if(obj.UpdatedByMailingTemplates!=null)
			{
				_updatedByMailingTemplatesProperty=obj.UpdatedByMailingTemplates.CurrentDTO;
			}
        }
	// ZeroOrOneToMany
	
        private List<MailingTemplateDTO>  _updatedByMailingTemplatesProperty=new List<MailingTemplateDTO>();
        public List<MailingTemplateDTO> UpdatedByMailingTemplates
        {
			get
			{
				return  _updatedByMailingTemplatesProperty;
			}
			
		}
	
	
	
	
	
	
        private AddressDTO  _physicalAddressAddressProperty=null;
        public AddressDTO PhysicalAddressAddress
        {
			get
			{
				return  _physicalAddressAddressProperty;
			}
			set
			{
				 _physicalAddressAddressProperty=value;
			}
			
		}
        public void LoadPhysicalAddressAddress(ApplicationUser obj)
		{
			if(obj.PhysicalAddressAddress!=null)
			{
				_physicalAddressAddressProperty=obj.PhysicalAddressAddress.CurrentDTO;
			}
		}
		
		
        private AddressDTO  _postalAddressAddressProperty=null;
        public AddressDTO PostalAddressAddress
        {
			get
			{
				return  _postalAddressAddressProperty;
			}
			set
			{
				 _postalAddressAddressProperty=value;
			}
			
		}
        public void LoadPostalAddressAddress(ApplicationUser obj)
		{
			if(obj.PostalAddressAddress!=null)
			{
				_postalAddressAddressProperty=obj.PostalAddressAddress.CurrentDTO;
			}
		}
		
		
        private ApplicationRoleDTO  _applicationRoleProperty=null;
        public ApplicationRoleDTO ApplicationRole
        {
			get
			{
				return  _applicationRoleProperty;
			}
			set
			{
				 _applicationRoleProperty=value;
			}
			
		}
        public void LoadApplicationRole(ApplicationUser obj)
		{
			if(obj.ApplicationRole!=null)
			{
				_applicationRoleProperty=obj.ApplicationRole.CurrentDTO;
			}
		}
		
		
        private ApplicationUserDTO  _updatedByApplicationUser1Property=null;
        public ApplicationUserDTO UpdatedByApplicationUser1
        {
			get
			{
				return  _updatedByApplicationUser1Property;
			}
			set
			{
				 _updatedByApplicationUser1Property=value;
			}
			
		}
        public void LoadUpdatedByApplicationUser1(ApplicationUser obj)
		{
			if(obj.UpdatedByApplicationUser1!=null)
			{
				_updatedByApplicationUser1Property=obj.UpdatedByApplicationUser1.CurrentDTO;
			}
		}
		
		
        private ApplicationUserDTO  _updatedByApplicationUser2Property=null;
        public ApplicationUserDTO UpdatedByApplicationUser2
        {
			get
			{
				return  _updatedByApplicationUser2Property;
			}
			set
			{
				 _updatedByApplicationUser2Property=value;
			}
			
		}
        public void LoadUpdatedByApplicationUser2(ApplicationUser obj)
		{
			if(obj.UpdatedByApplicationUser2!=null)
			{
				_updatedByApplicationUser2Property=obj.UpdatedByApplicationUser2.CurrentDTO;
			}
		}
		
		
        private DataOptionDTO  _dataOptionProperty=null;
        public DataOptionDTO DataOption
        {
			get
			{
				return  _dataOptionProperty;
			}
			set
			{
				 _dataOptionProperty=value;
			}
			
		}
        public void LoadDataOption(ApplicationUser obj)
		{
			if(obj.DataOption!=null)
			{
				_dataOptionProperty=obj.DataOption.CurrentDTO;
			}
		}
		
		
			



        #endregion

    }
}