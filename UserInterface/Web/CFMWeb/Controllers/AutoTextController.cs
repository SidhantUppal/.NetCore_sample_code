using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "CheckUserLoggedIn")]
    public class AutoTextController : BaseController
    {
        [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}/{SecondParentID}/{thirdParent}/{fourthParent}/{fifthParent}/{currentSelections}")]
        public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null,
            string SecondParentID = null, string thirdParent = null, string fourthParent = null,
            string fifthParent = null,
            string currentSelections=null)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();


            commandParams.Add("p_code", code);
            if (!string.IsNullOrEmpty(term) && term != "EMPTY")
            {
                commandParams.Add("p_term", term);
            }
            else
            {
                commandParams.Add("p_term", "");
            }

            if (!string.IsNullOrEmpty(ParentID) && ParentID != "EMPTY")
            {
                commandParams.Add("p_ParentID", ParentID);
            }

            if (CurrentID.HasValue && CurrentID != -99999)
            {
                commandParams.Add("p_CurrentID", CurrentID.Value);
            }

            if (!string.IsNullOrEmpty(SecondParentID) && SecondParentID != "EMPTY")
            {
                commandParams.Add("p_SecondParentID", SecondParentID);
            }

            if (!string.IsNullOrEmpty(thirdParent) && thirdParent != "EMPTY")
            {
                commandParams.Add("p_thirdParent", thirdParent);
            }

            if (!string.IsNullOrEmpty(fourthParent) && fourthParent != "EMPTY")
            {
                commandParams.Add("p_fourthParent", fourthParent);
            }

            if (!string.IsNullOrEmpty(fifthParent) && fifthParent != "EMPTY")
            {
                commandParams.Add("p_fifthParent", fifthParent);
            }

            if (!string.IsNullOrEmpty(currentSelections) && currentSelections != "EMPTY")
            {
                commandParams.Add("p_currentSelections", currentSelections);
            }
      DynamicList lst = DynamicList.GetData("spCFM_AutoText", commandParams);
            if (lst.Count > 0)
            {
                return (JArray) lst[0].GetValue("Data");
            }

            return null;
        }


        [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}/{SecondParentID}/{thirdParent}/{fourthParent}/{fifthParent}")]
    public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null,
            string secondParentID = null, string thirdParent = null, string fourthParent = null, string fifthParent = null)
        {
            return Get(code, term, ParentID, CurrentID, secondParentID, thirdParent, fourthParent, fifthParent,null);
        }

    [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}/{SecondParentID}/{thirdParent}/{fourthParent}")]
        public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null,
            string secondParentID = null, string thirdParent = null, string fourthParent = null)
        {
            return Get(code, term, ParentID, CurrentID, secondParentID, thirdParent, fourthParent, null);
        }

        [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}/{SecondParentID}/{thirdParent}")]
        public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null,
            string secondParentID = null, string thirdParent = null)
        {
            return Get(code, term, ParentID, CurrentID, secondParentID, thirdParent, null, null);
        }

        [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}/{SecondParentID}")]
        public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null,
            string secondParentID = null)
        {
            return Get(code, term, ParentID, CurrentID, secondParentID, null, null, null);
        }

        [HttpGet("{code}/{term}/{ParentID?}/{CurrentID?}")]
        public JArray Get(string code, string term, string ParentID = null, int? CurrentID = null)
        {
            return Get(code, term, ParentID, CurrentID, null, null, null, null);
        }

        [HttpGet("{code}/{term}")]
        public JArray Get(string code, string term)
        {
            return Get(code, term, null, null);
        }

        [HttpGet("{code}")]
        public JArray Get(string code)
        {
            return Get(code, "", null, null);
        }
    }
}