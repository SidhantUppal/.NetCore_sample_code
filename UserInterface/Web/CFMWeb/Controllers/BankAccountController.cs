using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        [HttpGet("{bankAccountId}")]
        public BankAccountDTO Get(int bankAccountId)
        {
            BankAccount ba = BankAccount.GetByBankAccountID(bankAccountId);
            ba.CurrentDTO.LoadBankAccountCards(ba);
            return ba.CurrentDTO;
             
        }

        [HttpGet("card/{bankAccountId}")]
        public JArray GetBankCards(int? bankAccountId)
        {            
            Dictionary<string, object> commandParams = new Dictionary<string, object>();
            if (bankAccountId.HasValue) 
            {
                commandParams.Add("p_BankAccountID", bankAccountId); 
            }
            DynamicList lst = DynamicList.GetData("spCFM_BankAccountCard_Select", commandParams);

            if (lst.Count > 0)
            {
                return (JArray)lst[0].GetValue("Data");
            }

            return null;
        }

       
    }
}