using Microsoft.AspNetCore.Mvc;
using Samples.WebApp.Business;

namespace Samples.WebApp.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly IDataBusiness _dataBusiness;

        public HomeController(IDataBusiness dataBusiness)
        {
            _dataBusiness = dataBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataBusiness.GetData());
        }
    }
}