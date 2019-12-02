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

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CFMUser")]
    public class HomeManagementController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody]HomeSearch data)
        {

            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageStart", data.PageStart);

            if (data.PageSize > 0)
            {
                commandParams.Add("@p_PageSize", data.PageSize);
            }

            commandParams.Add("@p_ApplicationUserID", CurrentUserID);

            if (data.HomeID.HasValue)
            {
                commandParams.Add("@p_HomeID", data.HomeID.Value);
            }

            commandParams.Add("@p_ShowInactive", data.ShowInactive);


            DynamicList lst = DynamicList.GetData("spCFM_Home_SelectForGrid", commandParams);
            if (lst.Count > 0)
            {
                return (JArray)lst[0].GetValue("Data");
            }

            return null;
        }

        [HttpGet]
        [Route("GetHomeDetails/{homeID}")]
        public JArray GetHomeDetails(int homeID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_HomeID", homeID);

            DynamicList lst = DynamicList.GetData("spCFM_HomeDetails_Select", commandParams);

            return lst.GetJson();
        }

        [HttpPost("[action]")]
        public bool SaveHomeDetails([FromBody] SaveHomeDetailsRequest request)
        {
            try
            {
                var existingHome = Home.GetByHomeID(request.Home.HomeID);
                request.Home.CustomCopyDTO(existingHome);

                var currentTime = DateTime.Now;

                if (existingHome.AddressID.HasValue)
                {
                    var existingAddress = Address.GetByAddressID(existingHome.AddressID.Value);

                    request.Address.CustomCopyDTO(existingAddress);

                    if (existingAddress.IsDirty)
                    {
                        existingAddress.UpdatedBy = CurrentUserID;
                        existingAddress.UpdatedOn = currentTime;
                    }

                    existingAddress.Save();
                }
                else
                {
                    var newAddress = Address.NewAddress();
                    request.Address.CustomCopyDTO(newAddress);
                    request.Address.IsActive = true;
                    newAddress.CreatedBy = CurrentUserID;
                    newAddress.CreatedOn = currentTime;

                    var address = newAddress.Save();
                    existingHome.AddressID = address.AddressID;
                }

                if (existingHome.IsDirty)
                {
                    existingHome.UpdatedBy = CurrentUserID;
                    existingHome.UpdatedOn = currentTime;
                }

                existingHome.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("GetHomeGLAccountDetails/{homeID}")]
        public JArray GetHomeGLAccountDetails(int homeID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_HomeID", homeID);

            DynamicList lst = DynamicList.GetData("spCFM_HomeGLAccountDetails_Select", commandParams);

            if (lst.Count > 0)
            {
                return (JArray)lst[0].GetValue("Data");
            }

            return null;
        }
    }
}
