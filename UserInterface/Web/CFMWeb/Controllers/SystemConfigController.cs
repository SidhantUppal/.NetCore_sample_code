using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CFMData;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigController : BaseController
    {
        [HttpGet]
        public List<SystemConfigDTO> Get()
        {
            return SystemConfigList.GetForUI().CurrentDTO;
        }
    }
}