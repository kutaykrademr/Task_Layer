using Helpers;
using Helpers.HelperModels;
using Microsoft.AspNetCore.Mvc;

namespace Task.API.Controllers
{ 
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet("GetAppInfo", Name = "GetAppInfo")]
        public MonitizerResult GetAppInfo()
        {
            var x = Constants.monitizer.GetMonitizerResult();
            return Constants.monitizer.GetMonitizerResult();
        }
    }
}
