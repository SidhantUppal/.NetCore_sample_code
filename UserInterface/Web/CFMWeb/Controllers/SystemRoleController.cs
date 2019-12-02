using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
  public class SystemRoleController : ControllerBase
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody]BaseGridSearch data)
        {
      Dictionary<string, object> commandParams = data.GetParams();

    

      DynamicList lst = DynamicList.GetData("spCFM_SystemRole_SelectForGrid", commandParams);
      if (lst.Count > 0)
      {
          return (JArray)lst[0].GetValue("Data");
      }

      return null;
    }

        [HttpPost("[action]")]
        public JArray SearchByApplicationRole([FromBody]SystemRoleSearch data)
        {
      Dictionary<string, object> commandParams = data.GetParams();

      if (data.ApplicationRoleID.HasValue)
      {
          commandParams.Add("@p_ApplicationRoleID", data.ApplicationRoleID.Value);
      }
      


      DynamicList lst = DynamicList.GetData("spCFM_SystemRole_ByApplicationRole", commandParams);
      if (lst.Count > 0)
      {
          return (JArray)lst[0].GetValue("Data");
      }

      return null;
    }
  }
}