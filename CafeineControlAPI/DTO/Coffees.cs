namespace CaffeineControlAPI.DTO
{
    public class Coffees
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Coffees() { }

        public Coffees(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}