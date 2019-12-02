using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMCommon;
using CFMData;
using CFMData.Collections.Custom;
using CFMData.Custom;
using CFMData.Custom.Response;
using CFMWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAccountsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class UserManagerController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody] ApplicationUserSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);

            if (data.ApplicationRoleID.HasValue)
            {
                commandParams.Add("@p_ApplicationRoleID", data.ApplicationRoleID);
            }

            if (data.ApplicationUserID.HasValue)
            {
                commandParams.Add("@p_ApplicationUserID", data.ApplicationUserID);
            }

            commandParams.Add("@p_LoginName", data.LoginName);

            DynamicList lst = DynamicList.GetData("[dbo].[spCFM_ApplicationUser_SelectForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }

        [HttpGet]
        [Route("{login}/{userID?}")]
        public ApplicationUserDTO Get(string login, int? userID)
        {
            ApplicationUserList lstUser = ApplicationUserList.ValidateUser(login.Trim(), userID);
            if (lstUser.Count > 0)
            {
                return lstUser[0].CurrentDTO;
            }

            return null;

            //if (lstUser.Count > 0)
            //{
            //    return lstUser[0].CurrentDTO;
            //}

            return null;
        }

        [HttpGet]
        [Route("UserDetails/{userID?}")]
        public JArray Get(int userID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_ApplicationUserID", userID);

            DynamicList lst = DynamicList.GetData("[dbo].[spCFM_ApplicationUser_SelectForEdit]", commandParams);

            return lst.GetJson();
        }

        [HttpGet]
        [Route("SendActiveCheck/{userID}")]
        public SendActiveCheckResponse SendActiveCheck(int userID)
        {
            var response = new SendActiveCheckResponse();

            response.IsSuccess = false;

            try
            {
                ApplicationUser.SendActiveCheck(userID, CurrentUserID);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
            }

            return response;            
        }


        [HttpPost]
        public ApplicationUserDTO Post([FromBody] UserAccessMappingRequest data)
        {
            ApplicationUser current = ApplicationUser.NewApplicationUser();
            data.User.UpdatedBy = CurrentUserID;
            current.CustomSave(data, MD5Generator.ToMD5Hash(data.User.Password));
            var userDto = ApplicationUser.GetByApplicationUserID(current.ApplicationUserID).CurrentDTO;

            if (data.IsFinAdmin && data.User.ApplicationUserID <= 0)
            {
                FinAdministrator fad;
                DateTime CurrentTime = DateTime.Now;             

                if (data.FinAdminId <= 0)
                {
                    fad = FinAdministrator.NewFinAdministrator();
                    fad.CreatedOn = CurrentTime;
                    fad.CreatedBy = CurrentUserID;
                    fad.IsActive = true;
                    fad.AddressID = userDto.PhysicalAddressID;
                    fad.Name = $"{data.User.FirstName} {data.User.LastName} {userDto.ApplicationUserID}";
                    fad.IsOrganisation = false;
                    fad.Email = data.User.EmailAddress;
                }
                else
                {
                    fad = FinAdministrator.GetByFinAdministratorID(data.FinAdminId);
                }

                var finUsers = FinAdministratorAppUser.NewFinAdministratorAppUser();
                finUsers.FinAdministratorID = fad.FinAdministratorID;
                finUsers.ApplicationUserId = userDto.ApplicationUserID;
                finUsers.CreatedOn = CurrentTime;
                finUsers.CreatedBy = CurrentUserID;
                finUsers.IsActive = true;

                fad.FinAdministratorAppUsers.Add(finUsers);
                fad.Save();               
            }

            return userDto;
        }

        private bool HasAddress(AddressDTO address)
        {
            if (address == null)
            {
                return false;
            }
            return !string.IsNullOrEmpty(address.PostCode)
                   || !string.IsNullOrEmpty(address.Suburb)
                   || !string.IsNullOrEmpty(address.Street)
                   || address.CountryID != 0
                   || address.StateID != 0;
        }
    }
}