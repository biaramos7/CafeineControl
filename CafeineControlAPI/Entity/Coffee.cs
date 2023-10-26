namespace CaffeineControlAPI.Entity
{
    public class Coffee
    {
        public string Code { get; set; }    
        public string Name { get; set; }    
        public int CaffeineLevel { get; set; }

        public Coffee() { }

        public Coffee(string code, string name, int caffeineLevel)
        {
            this.Code = code;
            this.Name = name;
            this.CaffeineLevel = caffeineLevel;
        }
    }
}
