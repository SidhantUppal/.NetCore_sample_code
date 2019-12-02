using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataOptionController : BaseController
    {
        [HttpGet("[action]")]
    public JArray GetEditableOptionTypes()
    {
        Dictionary<string, object> commandParams = new Dictionary<string, object>();
       
        DynamicList lst = DynamicList.GetData("spCFM_DataOptionType_SelectForEdit", commandParams);
        if (lst.Count > 0)
        {
            return (JArray)lst[0].GetValue("Data");
        }

        return null;
    }
    [HttpGet("[action]")]
    public JArray GetDataOptionTypeSort()
    {
      


      

        DynamicList lst = DynamicList.GetData("spCFM_DataOptionTypeSort_Select",null);
        if (lst.Count > 0)
        {
            return (JArray)lst[0].GetValue("Data");
        }

        return null;
    }

    [HttpGet("")]
    [Route("GetValidDataOptions/{dataoptionTypeID}/{currentID?}")]
    public List<DataOptionDTO> GetValidDataOptions(int dataoptionTypeID, int? currentID)
    {



        return ValidDataOptions(dataoptionTypeID, currentID);


    }

  }
}