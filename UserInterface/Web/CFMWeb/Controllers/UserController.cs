using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        [HttpGet]
        public async Task<LoginUserResponse> Get()
        {
            LoginUserResponse resp = new LoginUserResponse();
            resp.IsSuccess = false;
            if (HttpContext.User != null && HttpContext.User.Identity != null)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    resp = await SigninUser(HttpContext.User.Identity.Name);


                }
            }

            return resp;

        }

        [HttpGet("[action]")]
        public async Task<string> Logout()
        {
            await HttpContext.SignOutAsync();

            return "";
        }
  }
}