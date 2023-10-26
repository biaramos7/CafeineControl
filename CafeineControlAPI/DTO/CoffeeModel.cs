using CafeineControlAPI.DTO;

namespace CaffeineControlAPI.DTO
{
    public class CoffeeModel
    {
       public List<Coffees> Coffees { get; set; }

        public CoffeeModel(List<Coffees> coffees)
        {
            Coffees = coffees;
        }
    }
}