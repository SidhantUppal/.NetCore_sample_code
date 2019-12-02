using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMCommon;
using CFMData;
using CFMData.Collections.Custom;
using CFMData.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class ApplicationRoleController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody] CFMData.ApplicationRoleSearch data)
        {

            Dictionary<string, object> commandParams = data.GetParams();

            if (data.ApplicationRoleID.HasValue)
            {
                commandParams.Add("@p_ApplicationRoleID", data.ApplicationRoleID.Value);
            }
            commandParams.Add("@p_Search", data.Name);
            commandParams.Add("@p_ShowInactive", data.ShowInactive);


            DynamicList lst = DynamicList.GetData("spCFM_ApplicationRole_SelectForGrid", commandParams);
            if (lst.Count > 0)
            {
                return (JArray)lst[0].GetValue("Data");
            }

            return null;
        }

        [HttpGet("{applicationRoleName}/{applicationRoleID?}")]
        public ApplicationRoleDTO Get(string applicationRoleName, int? applicationRoleID)
        {
            ApplicationRoleList lst = ApplicationRoleList.ValidateRole(applicationRoleName.Trim(), applicationRoleID);
            if (lst.Count > 0)
            {
                return lst[0].CurrentDTO;

            }

            return null;
        }

        [HttpGet]
        [Route("RoleDetails/{roleID?}")]
        public JArray Get(int roleID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_ApplicationRoleID", roleID);

            DynamicList lst = DynamicList.GetData("[dbo].[spCFM_ApplicationRole_SelectForEdit]", commandParams);

            return lst.GetJson();
        }


        [HttpPost]
        public ApplicationRoleDTO Post([FromBody] RoleAccessMappingRequest data)
        {
            ApplicationRole current = ApplicationRole.NewApplicationRole();

            data.Role.UpdatedBy = CurrentUserID;

            current.CustomSave(data);

            return ApplicationRole.GetByApplicationRoleID(current.ApplicationRoleID).CurrentDTO;            
        }      
    }
}