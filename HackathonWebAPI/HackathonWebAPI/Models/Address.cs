namespace HackathonWebAPI.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }
        public string CountryCode { get; set; }
        public int PostalCode { get; set; }
    }

    public class State
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
