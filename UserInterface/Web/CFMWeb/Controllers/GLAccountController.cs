using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CFMData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class GLAccountController : BaseController
    {

        [HttpGet]
        [Route("ValidateGLAccount/")]
        public GLAccountDTO ValidateGLAccount(string accountCode, int? glAccountID)
        {
            GLAccountList glAccount = GLAccountList.ValidateAccountCode(accountCode.Trim(), glAccountID);
            if (glAccount.Count > 0)
            {
                return glAccount[0].CurrentDTO;
            }

            return null;
        }

        [HttpGet]
        [Route("ValidateGLAccountAndEntityType/{accountTypeID}/{entityTypeID}/{glAccountID?}")]
        public GLAccountDTO ValidateGLAccountAndEntityType(int accountTypeID, int entityTypeID, int? glAccountID)
        {
            GLAccountList glAccount = GLAccountList.ValidateGLAccountAndEntityType(accountTypeID, entityTypeID, glAccountID);
            if (glAccount.Count > 0)
            {
                return glAccount[0].CurrentDTO;
            }

            return null;
        }

        [HttpGet("{glAccountId}")]
        public GLAccountDTO Get(int glAccountId)
        {
            GLAccount glAccount = GLAccount.GetByGLAccountID(glAccountId);

            glAccount.CurrentDTO.LoadBankAccount(glAccount);

            glAccount.CurrentDTO.BankAccount.LoadBankAccountCards(glAccount.BankAccount);
            return glAccount.CurrentDTO;

        }     
    }
}