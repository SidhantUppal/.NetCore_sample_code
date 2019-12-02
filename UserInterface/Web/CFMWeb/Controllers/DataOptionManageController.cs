using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CFMData;

namespace CFMWeb.Controllers
{
    public class DataOptionChanges
    {

        public int DataOptionTypeID { get; set; }
        public int SortTypeID { get; set; }

        public IEnumerable<DataOptionDTO> ChangedValues { get; set; }


    }

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "AdminRole")]
    public class DataOptionManageController : BaseController
    {
        [HttpPost]
        public List<DataOptionDTO> Post([FromBody] DataOptionChanges data)
        {
            DataOptionType dataOptionType = DataOptionType.GetByDataOptionTypeID(data.DataOptionTypeID);
            dataOptionType.DataOptionTypeSortID = data.SortTypeID;
            if (dataOptionType.IsDirty)
            {
                dataOptionType.UpdatedBy = CurrentUserID;
                dataOptionType.UpdatedOn = DateTime.Now;
            }

            if (data.ChangedValues != null)
            {
                int displayOrder = 1;
                foreach (DataOptionDTO dataOptionDto in data.ChangedValues)
                {
                    DataOption dataOption =
                        dataOptionType.DataOptions.FirstOrDefault(x => x.DataOptionID == dataOptionDto.DataOptionID);


                    if (dataOption == null)
                    {
                        dataOption = new DataOption();
                        dataOption.DataOptionTypeID = data.DataOptionTypeID;
                        dataOption.Code = dataOptionDto.DisplayValue;
                        dataOption.ActiveFrom = DateTime.Now;
                        dataOption.CreatedBy = CurrentUserID;
                        dataOption.CreatedOn = DateTime.Now;
                    }
                    else
                    {
                        if (dataOptionDto.isDeleted)
                        {
                            dataOption.ActiveTo = DateTime.Now;
                        }
                    }
                    dataOption.Code = dataOptionDto.Code;
          dataOption.DisplayValue = dataOptionDto.DisplayValue;
                    dataOption.SortID = displayOrder * 1000;
                    if (dataOption.IsDirty && !dataOption.IsNew)
                    {
                        dataOption.UpdatedBy = CurrentUserID;
                        dataOption.UpdatedOn = DateTime.Now;
                    }

                    displayOrder++;
                    dataOption.Save();
                }
            }

            dataOptionType.Save();
            return ValidDataOptions(data.DataOptionTypeID, null);
        }

    }
}