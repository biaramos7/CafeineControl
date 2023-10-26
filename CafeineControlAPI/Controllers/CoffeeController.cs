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
        private readonly ILogger<Coffee> _logger;


        public CoffeeController(IConfiguration configuration, ILogger<Coffee> logger)
        {
            this._config = configuration;
            this._logger = logger;
        }

        [HttpGet]
        [Route("coffees")]
        public async Task<IResult> ListCoffees() 
        {
            try
            {
                return Results.Ok(await CoffeeService.GetCoffees());
            }
            catch(Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
