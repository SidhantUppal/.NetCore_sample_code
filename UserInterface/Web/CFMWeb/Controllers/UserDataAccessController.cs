using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData.Collections.Custom;
using CFMData.Custom;
using CFMWeb.Controllers;
using System.Collections.Generic;

namespace WebAccountsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class UserDataAccessController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody]ApplicationUserSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_ApplicationUserID", data.ApplicationUserID);

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);

            DynamicList lst = DynamicList.GetData("[dbo].[spCFM_ApplicationUserDataAccess_SelectForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }
    }
}
