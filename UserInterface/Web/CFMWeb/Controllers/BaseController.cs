using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMCommon;
using CFMData;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    public class BaseController : ControllerBase
    {
        public async Task<LoginUserResponse> SigninUser(string LoginName)
        {
            LoginUserResponse resp = new LoginUserResponse();
            resp.IsSuccess = false;
            if (!string.IsNullOrEmpty(LoginName))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LoginName)
                    //,new Claim(UserClaims.Suppliers.ToString(), jToken.ToString())
                };
                Dictionary<string, object> commandParams = new Dictionary<string, object>();
                commandParams.Add("p_username", LoginName);


                DynamicList lst = DynamicList.GetData("spCFM_ApplicationUser_Details", commandParams);
                string systemRoles = "";
                string userRegions = "";
                string userSuppliers = "";
                if (lst.Count > 0)
                {

                    JArray dbData = (JArray) lst[0].GetValue("Data");



                    if (dbData.Count > 0)
                    {
                        foreach (JToken jToken in dbData)
                        {


                            resp.MustChangePassword = jToken.Value<Boolean>("mustChangePassword");
                            resp.ForceChangePassword = jToken.Value<Boolean>("forceChangePassword");

              systemRoles = jToken.Value<string>("systemRoleName");
                            if (!string.IsNullOrEmpty(systemRoles))
                            {
                                claims.Add(new Claim(UserClaims.Roles.ToString(), systemRoles));
              }
                            
                            resp.roles = systemRoles;
              claims.Add(new Claim(CFMCommon.UserClaims.UserID.ToString(),jToken["applicationUserID"].ToString()));
                            break;
                        }
                    }

                    
                }

                
                //claims.Add(new Claim(UserClaims.Suppliers.ToString(), userSuppliers));
                //claims.Add(new Claim(UserClaims.Regions.ToString(), userRegions));
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				
				 var authProperties = new AuthenticationProperties
    {
        AllowRefresh = true,
        ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(86400),
        IsPersistent = true,
        IssuedUtc = DateTimeOffset.UtcNow,
        RedirectUri = null
    };


                //await HttpContext.SignInAsync(principal);
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,authProperties);

                resp.IsSuccess = true;
                
                //resp.suppliers = userSuppliers;
                //resp.regions = userRegions;

                resp.userName = LoginName;
            }

            return resp;
        }

        public List<DataOptionDTO> ValidDataOptions(int dataoptionTypeID, int? currentID)
        {
            DataOptionList values = DataOptionList.GetValidDataOptions(dataoptionTypeID, currentID);
            return values.GetTree();
        }

        public int CurrentUserID
        {
            get
            {

                if (!HttpContext.User.HasClaim(c => c.Type == UserClaims.UserID.ToString()))
                {
                    return 0;
                }

                return Convert.ToInt32(HttpContext.User.FindFirst(c => c.Type == UserClaims.UserID.ToString()).Value);

            }
        }
    }
}