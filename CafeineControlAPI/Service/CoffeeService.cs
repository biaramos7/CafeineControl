using CafeineControlAPI.DTO;
using CaffeineControlAPI.Data;
using CaffeineControlAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace CaffeineControlAPI.Service
{
    public class CoffeeService
    {
        public static async Task<CoffeeModel> GetCoffees(IConfiguration config)
        {
            var connectionString = config.GetValue<string>("ConnectionString");

            if (connectionString == null) throw new Exception("ConnectionString must be configured");

            using var conn = new CoffeeContext(connectionString);
            var result = conn.Coffee.Select(x => new Coffees(x.Name, x.Code)).ToList();

            return new CoffeeModel(result);
        }
    }
}
