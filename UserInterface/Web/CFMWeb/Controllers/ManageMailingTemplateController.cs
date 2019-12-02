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
using CFMData.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
  public class ManageMailingTemplateController : BaseController
    {
        [HttpPost("[action]")]
        public JArray Search([FromBody] EmailTemplateSearch data)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("@p_SortColumn", data.SortColumn);
            commandParams.Add("@p_SortOrder", data.SortOrder);
            commandParams.Add("@p_PageSize", data.PageSize);
            commandParams.Add("@p_PageStart", data.PageStart);


            commandParams.Add("@p_RefundAction", data.Description);
            commandParams.Add("@p_FromDate", data.MailingSubject);
            commandParams.Add("@p_ToDate", data.MailingText);

           

            DynamicList lst = DynamicList.GetData("[dbo].[spCCR_GetTransactionActionForGrid]", commandParams);

            if (lst.Count > 0)
            {
                var data1 = (JArray)lst[0].GetValue("Data");
                return data1;
            }

            return null;
        }

        [HttpGet]
        public JArray Get()
        {
            DynamicList lst = DynamicList.GetData("spCFM_MailingTemplate_Select", null);

            if (lst.Count > 0)
            {
                return (JArray)lst[0].GetValue("Data");
            }

            return null;
        }



        [HttpPost]
        public void Post([FromBody] MailingTemplateDTO data)
        {
            MailingTemplate mailingTemplate = MailingTemplate.GetByMailingTemplateID(data.MailingTemplateID);
            mailingTemplate.Description = data.Description;
            mailingTemplate.MailingText = data.MailingText;
            mailingTemplate.MailingSubject = data.MailingSubject;
            mailingTemplate.MailingFrom = data.MailingFrom;
            if (mailingTemplate.IsDirty)
            {
                mailingTemplate.UpdatedOn = DateTime.Now;
                mailingTemplate.UpdatedBy = CurrentUserID;
            }


            mailingTemplate.CustomSave();
        }
  }
}