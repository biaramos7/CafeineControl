namespace CafeineControlAPI.DTO
{
    public class Recommendations
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Wait { get; set; }

        public Recommendations(string code, string name, int wait)
        {
            Code = code;
            Name = name;
            Wait = wait;
        }
    }
}
