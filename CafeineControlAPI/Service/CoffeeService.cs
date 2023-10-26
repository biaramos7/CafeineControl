using CafeineControlAPI.DTO;
using CaffeineControlAPI.Data;
using CaffeineControlAPI.DTO;
using CaffeineControlAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CaffeineControlAPI.Service
{
    public class CoffeeService
    {
        public static async Task<CoffeeModel> GetCoffees(CoffeeContext context)
        {
            using var conn = context;
            var result = conn.Coffee.Select(x => new Coffees(x.Name, x.Code)).ToList();

            return new CoffeeModel(result);
        }

        public static async Task<RecommendationsModel> Calculate(CoffeeContext context, IConfiguration config, ConsumptionModel consumptionModel)
        {
            using var conn = context;

            List<Coffee> registesredCoffees = conn.Coffee.ToList();

            //Identify caffeine level in the body
            decimal remainingCaffeine = 0;
            consumptionModel.consumption.ForEach(x =>
            {
                decimal caffeineLevel = registesredCoffees.Where(a => a.Code == x.Code).Select(a => a.CaffeineLevel).First();
                remainingCaffeine += CalculateRemainingCaffeine(caffeineLevel, x.Time);
            });

            var result = new RecommendationsModel();
            registesredCoffees.ForEach(x =>
            {
                var recommendation = new Recommendations(x.Code, x.Name, CalculateWaitTime(remainingCaffeine, x.CaffeineLevel));
                result.Recommendations.Add(recommendation);
            });

            return result;
        }

        public static decimal CalculateRemainingCaffeine(decimal caffeineLevel, int time)
        {
            decimal exp = time / 300M;
            decimal remaining = caffeineLevel * (decimal)Math.Pow(0.5, (double)exp);
            return remaining;
        }

        public static int CalculateWaitTime(decimal remainingCaffeine, decimal caffeineLevel)
        {
            //Maximum desired caffeine level -> 175mg
            if (remainingCaffeine < (175 - caffeineLevel))
            {
                return 0;
            }
            else
            {
                double n = (double)((175 - caffeineLevel) / remainingCaffeine);
                decimal wait = (decimal)(Math.Log(n, 0.5)) * 300M;

                return (int)Math.Ceiling(wait);
            }
        }
    }
}
