using CaffeineControlAPI.Service;
using CaffeineControlAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CaffeineControlAPI.Controller
{
    [ApiController]
    [Route("v1")]
    public class CoffeeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CoffeeController(IConfiguration configuration)
        {
            this._config = configuration;
        }

        [HttpGet]
        [Route("coffees")]
        public async Task<IActionResult> ListCoffees() 
        {
            try
            {
                var result = await CoffeeService.GetCoffees(_config);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
