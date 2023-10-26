using CaffeineControlAPI.Service;
using CaffeineControlAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using CafeineControlAPI.DTO;
using CaffeineControlAPI.Data;

namespace CaffeineControlAPI.Controller
{
    [ApiController]
    [Route("v1")]
    public class CoffeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CoffeeContext _context;

        public CoffeeController(IConfiguration configuration)
        {
            this._config = configuration;
            this._context = new CoffeeContext(configuration.GetValue<string>("ConnectionString"));
        }

        [HttpGet]
        [Route("coffees")]
        public async Task<IActionResult> ListCoffees() 
        {
            try
            {
                var result = await CoffeeService.GetCoffees(_context);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> Calculate([FromBody] ConsumptionModel consumption)
        {
            try
            {
                var result = await CoffeeService.Calculate(_context, _config, consumption);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
