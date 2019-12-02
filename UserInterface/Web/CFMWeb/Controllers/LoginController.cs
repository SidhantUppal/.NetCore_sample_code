using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CFMCommon;
using CFMData;

namespace CFMWeb.Controllers
{
    public class LoginUserResponse
    {
        public bool IsSuccess { get; set; }
        private string errMessage = "";

        public string ErrorMessage
        {
            get { return errMessage; }
            set { errMessage = value; }
        }
        public object Data { get; set; }
        public string userName { get; set; }
    public string roles { get; set; }
    public Boolean MustChangePassword { get; set; }
    public bool ForceChangePassword { get; set; }
    }
  [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
  {
    // POST api/values
    [HttpPost]
    public async Task<LoginUserResponse> Post([FromBody]ApplicationUserDTO data)
    {
      LoginUserResponse resp = new LoginUserResponse();
      resp.IsSuccess = false;
      try
      {
        ApplicationUser user = ApplicationUser.LoginUser(data.LoginName, MD5Generator.ToMD5Hash(data.Password));
        if (user != null)
        {

          resp = await SigninUser(user.LoginName);
          resp.MustChangePassword = user.MustChangePassword;
          resp.ForceChangePassword = user.ForceChangePassword;




        }

      }
      catch (Exception e)
      {


      }

      return resp;
    }



    [HttpPost("[action]")]
    public async Task<LoginUserResponse> ResetPassword([FromBody]ApplicationUserDTO data)
    {
      LoginUserResponse resp = new LoginUserResponse();
      resp.IsSuccess = false;
      try
      {
        ApplicationUser.ResetPassword(data.LoginName, data.ApplicationUserID);
        resp.IsSuccess = true;
      }
      catch (Exception e)
      {


      }

      return resp;
    }




    [HttpPost("[action]")]
    public async Task<LoginUserResponse> ChangePassword([FromBody]ApplicationUserDTO data)
    {
      LoginUserResponse resp = new LoginUserResponse();
      resp.IsSuccess = false;
      try
      {
        ApplicationUser.ChangePassword(data.LoginName, MD5Generator.ToMD5Hash(data.Password));
        resp.IsSuccess = true;




      }
      catch (Exception e)
      {


      }

      return resp;
    }



    [HttpPost("[action]")]
    public async Task<LoginUserResponse> UpdatePassword([FromBody]ApplicationUserDTO data)
    {
      LoginUserResponse resp = new LoginUserResponse();
      resp.IsSuccess = false;
      try
      {
        ApplicationUser u = ApplicationUser.UpdatePassword(HttpContext.User.Identity.Name, MD5Generator.ToMD5Hash(data.CurrentPassword), MD5Generator.ToMD5Hash(data.Password));

        resp.IsSuccess = u.ApplicationUserID != 0;




      }
      catch (Exception e)
      {


      }

      return resp;
    }
  }
}