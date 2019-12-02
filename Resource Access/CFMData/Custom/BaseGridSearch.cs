using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class BaseGridSearch
    {
        public int PageStart { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
    }

    public class RuleSearch : BaseGridSearch
    {
        public string Name { get; set; }
        public int? RuleID { get; set; }
    }

    public class RuleSetSearch : BaseGridSearch
    {
        public string Name { get; set; }
        public int? RuleSetID { get; set; }
    }
    public class InvoiceReviewFilter : BaseGridSearch
    {

        public int InvoiceID { get; set; }
    }

    public class RuleVersionSearch : BaseGridSearch
    {
        public string Name { get; set; }
        public int RuleID { get; set; }
    }

    public class SpecialDealSearch : BaseGridSearch
    {
        public string SupplierName { get; set; }

        public int SpecialDealID { get; set; }
        public string Search { get; set; }

        public int? ProductID { get; set; }

        public int? ProductRangeID { get; set; }
        public int? MemberID { get; set; }
        public int? SupplierID { get; set; }

        public bool ShowHistory { get; set; }
    }


    public class SupplierRuleSetSearch : BaseGridSearch
    {
        public string SupplierName { get; set; }


        public int? SupplierID { get; set; }

        public int? RuleSetID { get; set; }
        public string RuleSetName { get; set; }
    }

    public class MemberGroupSearch : BaseGridSearch
    {
        public string MemberGroupName { get; set; }


        public int? MemberGroupID { get; set; }

        public int? MemberID { get; set; }
        public string MemberName { get; set; }
    }

    public class ApplicationRoleSearch : BaseGridSearch
    {
        public string Name { get; set; }

        public int? ApplicationRoleID { get; set; }

        public bool IsActive { get; set; }
    }

    public class ApplicationRoleSearchByUser : BaseGridSearch
    {
        public int ApplicationUserID { get; set; }
    }

    public class SystemRoleSearch : BaseGridSearch
    {
        public int? ApplicationRoleID { get; set; }
    }

    public class ApplicationUserSearch : BaseGridSearch
    {
        public string LoginName { get; set; }

        public int? ApplicationRoleID { get; set; }

        public int? ApplicationUserID { get; set; }
    }

    public class DataAccessByUserOrRoleSearch : BaseGridSearch
    {
        public int? ApplicationUserID { get; set; }

        public int? ApplicationRoleID { get; set; }
    }

    public class InvoiceProcessingSearch : BaseGridSearch
    {
        //public string UserRoles { get; set; }

        public int? PeriodID { get; set; }

        public string InvoiceNumber { get; set; }

        public int? RuleID { get; set; }

        public int? StatusID { get; set; }

        public int? SupplierTypeID { get; set; }

        public int? MemberID { get; set; }

        public int? SupplierID { get; set; }

        public int? ProductID { get; set; }

        public bool IncludeProcessed { get; set; }

        public bool ShowOnlyOutsideRange { get; set; }

        public bool ShowOnlyItemsForReview { get; set; }
    }

    public class InvoiceDetailSearch : BaseGridSearch
    {
        public string InvoiceID { get; set; }
    }

    public class InvoiceLineRebateSearch : BaseGridSearch
    {
        public int InvoiceLineID { get; set; }

        public bool IsSupplier { get; set; }
    }

    public class AccountSearch : BaseGridSearch
    {
        public string AccountName { get; set; }

        public int? AccountID { get; set; }

        public string AccountTypeName { get; set; }

        public int? AccountTypeID { get; set; }

        public int? AdministratorID { get; set; }

        public bool HighBalanceOnly { get; set; }

        public int? EntityTypeID { get; set; }

        public int? EntityID { get; set; }

        public bool ShowInactive { get; set; }
    }

    public class AccountStatementSearch : BaseGridSearch
    {
        public int? AccountID { get; set; }

        public int? AdministratorID { get; set; }

        public DateTime StatementPeriodDate { get; set; }

        public string AccountStatementType { get; set; }

        public int? StatementPeriodID { get; set; }

        public int? ClientID { get; set; }
    }

    public class TransactionActionSearch: BaseGridSearch
    {
        public string RefundAction { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int? BatchId { get; set; }
    }

    public class HomeSearch : BaseGridSearch
    {
        public int? HomeID { get; set; }

        public bool ShowInactive { get; set; }
    }
    public class FinAdministratorSearch : BaseGridSearch
    {
        public int? FinAdministratorID { get; set; }

        public bool ShowInactive { get; set; }
    }
    

    public class EmailTemplateSearch : BaseGridSearch
    {
        public string Description { get; set; }

        public DateTime MailingText { get; set; }

        public DateTime MailingSubject { get; set; }

    }

    public class ClientSearch : BaseGridSearch
    {
        public int? ClientID { get; set; }

        public string TechOneNumber { get; set; }

        public int? HomeID { get; set; }

        public bool ShowInactive { get; set; }
    }

    public class ClientAssignmentSearch : BaseGridSearch
    {
        public int EntityTypeID { get; set; }

        public int EntityID { get; set; }
    }
}
