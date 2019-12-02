using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class RefundController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody] TransactionActionSearch data)
        {           
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);

           
            commandParams.Add("@p_RefundAction", data.RefundAction);
            commandParams.Add("@p_FromDate", data.FromDate);
            commandParams.Add("@p_ToDate", data.ToDate);

            if (data.BatchId.HasValue)
            {
                commandParams.Add("@p_BatchId", data.BatchId.Value);
            }           

            DynamicList lst = DynamicList.GetData("[dbo].[spCCR_GetTransactionActionForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }
    }
}
