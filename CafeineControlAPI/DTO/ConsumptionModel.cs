namespace CafeineControlAPI.DTO
{
    public class ConsumptionModel
    {
        public List<Consumption> consumption { get; set; }

        public ConsumptionModel(List<Consumption> consumption)
        {
            this.consumption = consumption;
        }
    }
}
