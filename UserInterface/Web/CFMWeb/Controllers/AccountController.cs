using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData;
using CFMData.Collections.Custom;
using CFMData.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController : BaseController
    {
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CFMUser")]
        public JArray Search([FromBody] AccountSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);

            if (data.AccountID.HasValue)
            {
                commandParams.Add("@p_GLAccountID", data.AccountID.Value);
            }

            if (data.AccountTypeID.HasValue)
            {
                commandParams.Add("@p_GLAccountTypeID", data.AccountTypeID.Value);
            }

            if (data.AdministratorID.HasValue)
            {
                commandParams.Add("@p_AdministratorID", data.AdministratorID.Value);
            }

            if (data.EntityTypeID.HasValue)
            {
                commandParams.Add("@p_EntityTypeID", data.EntityTypeID.Value);
            }

            if (data.EntityID.HasValue)
            {
                commandParams.Add("@p_EntityID", data.EntityID.Value);
            }

            commandParams.Add("@p_HighBalanceOnly", data.HighBalanceOnly);
            commandParams.Add("@p_ShowInactive", data.ShowInactive);

            DynamicList lst = DynamicList.GetData("[dbo].[spCFM_GLAccount_SelectForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CFMUser")]
        public JArray SearchAccountStatementDetails([FromBody] AccountStatementSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);

            if (data.AccountID.HasValue)
            {
                commandParams.Add("@p_AccountID", data.AccountID.Value);
            }

            if (data.AdministratorID.HasValue)
            {
                commandParams.Add("@p_AdministratorID", data.AdministratorID.Value);
            }

            commandParams.Add("@p_AccountStatementType", data.AccountStatementType);

            commandParams.Add("@p_StatementmentPeriodDate", data.StatementPeriodDate);

            if (data.StatementPeriodID.HasValue)
            {
                commandParams.Add("@p_StatementPeriodID", data.StatementPeriodID.Value);
            }

            if (data.ClientID.HasValue)
            {
                commandParams.Add("@p_ClientID", data.ClientID.Value);
            }

            DynamicList lst = DynamicList.GetData("[dbo].[spCCR_AccountStatementDetails_SelectForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CFMUser")]
        public JArray SearchAccountStatementSummary([FromBody] AccountStatementSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            if (data.AccountID.HasValue)
            {
                commandParams.Add("@p_AccountID", data.AccountID.Value);
            }

            if (data.AdministratorID.HasValue)
            {
                commandParams.Add("@p_AdministratorID", data.AdministratorID.Value);
            }

            commandParams.Add("@p_AccountStatementType", data.AccountStatementType);

            commandParams.Add("@p_StatementmentPeriodDate", data.StatementPeriodDate);

            if (data.StatementPeriodID.HasValue)
            {
                commandParams.Add("@p_StatementPeriodID", data.StatementPeriodID.Value);
            }

            if (data.ClientID.HasValue)
            {
                commandParams.Add("@p_ClientID", data.ClientID.Value);
            }

            DynamicList lst = DynamicList.GetData("[dbo].[spCCR_AccountStatementSummary_SelectForGrid]", commandParams);

            if (lst.Count > 0)
            {
                return lst.GetJson();
            }

            return null;
        }

        [HttpGet("{glAccountId}")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CFMUser")]
        public JArray Get(int glAccountId)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_GLAccountId", glAccountId);

            return DynamicList.GetData("[dbo].[spCFM_GetAccountDetailsByGLAccountID]", commandParams).GetJson();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
        public bool SaveAccountDetails([FromBody] List<GLAccountDTO> data)
        {
            if (data != null && data.Count > 0)
            {
                GLEntity gLEntity = GLEntity.GetByGLEntityID(data[0].GLEntityID);

                DateTime CurrentTime = DateTime.Now;

                foreach (var account in data)
                {
                    GLAccount existingGLAccount = null;

                    if (gLEntity.GLAccounts != null && gLEntity.GLAccounts.Count > 0)
                    {
                        existingGLAccount =
                            gLEntity.GLAccounts.FirstOrDefault(x => x.GLAccountID == account.GLAccountID);
                    }

                    if (existingGLAccount == null)
                    {
                        if (account.GLAccountID > 0)
                        {
                            existingGLAccount = GLAccount.GetByGLAccountID(account.GLAccountID);
                            existingGLAccount.GLEntityID = gLEntity.GLEntityID;
                        }
                        else
                        {
                            existingGLAccount = GLAccount.NewGLAccount();
                            existingGLAccount.IsActive = true;
                            existingGLAccount.CreatedBy = CurrentUserID;
                            existingGLAccount.CreatedOn = CurrentTime;

                        }

                        gLEntity.GLAccounts.Add(existingGLAccount);

                    }

                    int? existingBankAccountID = existingGLAccount.BankAccountID;
                    BankAccount ba = null;
                    if (existingBankAccountID.HasValue && account.BankAccount == null)
                    {
                        // need to pull this as CustomCopyDTO function below will change bank account id to null
                        ba = existingGLAccount.BankAccount;
                    }

                    account.CustomCopyDTO(existingGLAccount);

                    if (!existingGLAccount.IsNew && existingGLAccount.IsDirty)
                    {
                        existingGLAccount.UpdatedBy = CurrentUserID;
                        existingGLAccount.UpdatedOn = CurrentTime;
                    }

                    if (account.BankAccount != null)
                    {

                        if (!account.BankAccountID.HasValue || account.BankAccountID < 0)
                        {
                            var bankAccount = BankAccount.NewBankAccount();
                            bankAccount.IsActive = true;
                            bankAccount.CreatedBy = CurrentUserID;
                            bankAccount.CreatedOn = CurrentTime;
                            existingGLAccount.SetBankAccount(bankAccount);
                        }

                        if (account.BankAccount.BankAccountCards != null &&
                            account.BankAccount.BankAccountCards.Count > 0)
                        {
                            foreach (var bankCard in account.BankAccount.BankAccountCards)
                            {
                                BankAccountCard existingBankCard = null;

                                if (existingGLAccount.BankAccount.BankAccountCards != null &&
                                    existingGLAccount.BankAccount.BankAccountCards.Count > 0)
                                {
                                    existingBankCard =
                                        existingGLAccount.BankAccount.BankAccountCards.FirstOrDefault(x =>
                                            x.BankAccountCardID == bankCard.BankAccountCardID);
                                }


                                if (existingBankCard == null)
                                {
                                    existingBankCard = BankAccountCard.NewBankAccountCard();
                                    existingBankCard.IsActive = true;
                                    existingBankCard.CreatedBy = CurrentUserID;
                                    existingBankCard.CreatedOn = CurrentTime;
                                    existingGLAccount.BankAccount.BankAccountCards.Add(existingBankCard);
                                }

                                bankCard.CustomCopyDTO(existingBankCard);

                                if (!existingBankCard.IsNew && existingBankCard.IsDirty)
                                {
                                    existingBankCard.UpdatedBy = CurrentUserID;
                                    existingBankCard.UpdatedOn = CurrentTime;
                                }
                            }
                        }

                        account.BankAccount.CustomCopyDTO(existingGLAccount.BankAccount);

                        if (!existingGLAccount.BankAccount.IsNew &&
                            (existingGLAccount.BankAccount.IsDirty
                             || existingGLAccount.BankAccount.IsChildDirty()))
                        {
                            existingGLAccount.IsDirty = true;
                            existingGLAccount.BankAccount.UpdatedBy = CurrentUserID;
                            existingGLAccount.BankAccount.UpdatedOn = CurrentTime;
                        }
                    }
                    else
                    {
                        if (ba != null)
                        {

                            existingGLAccount.IsDirty = true;
                            ba.IsActive = false;
                            ba.UpdatedBy = CurrentUserID;
                            ba.UpdatedOn = CurrentTime;
                            existingGLAccount.SetBankAccount(ba, true);

                        }
                    }
                }

                if (gLEntity.IsDirty)
                {
                    gLEntity.UpdatedBy = CurrentUserID;
                    gLEntity.UpdatedOn = CurrentTime;

                }

                gLEntity.Save();

                return true;
            }

            return false;
        }

        [HttpGet]
        [Route("ValidateBankAccount/{bSBDetailID}/{accountNumber}/{bankAccountID?}")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
        public BankAccountDTO ValidateBankAccount(int bSBDetailID, string accountNumber, int? bankAccountID)
        {
            BankAccountList bankAccount =
                BankAccountList.ValidateBankAccount(bSBDetailID, accountNumber, bankAccountID);
            if (bankAccount.Count > 0)
            {
                return bankAccount[0].CurrentDTO;
            }

            return null;
        }

    }
}