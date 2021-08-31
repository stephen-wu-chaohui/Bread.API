using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bread.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("get-settings")]
        public IActionResult GetSettings()
        {
            var settings = new 
            {
                AppName = _configuration["Settings-AppName"],
                Language = _configuration["Settings-Language"],
                Messages = _configuration["Settings-Messages"],
                ConnectionString = _configuration.GetConnectionString("Default")
            };

            return Ok(settings);
        }
    }
}
