using System.Security.Policy;

namespace CafeineControlAPI.DTO
{
    public class Consumption
    {
        public string Code { get; set; }
        public int Time { get; set; }

        public Consumption(string code, int time)
        {
            this.Code = code;
            this.Time = time;
        }
    }
}
