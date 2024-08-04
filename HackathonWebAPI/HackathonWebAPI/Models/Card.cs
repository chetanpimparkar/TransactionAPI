namespace HackathonWebAPI.Models
{
    public class Card
    {
        public string Number { get; set; }
        public string IssuedBy { get; set; }

        public string CardHolderName { get; set; }

        public int CVV { get; set; }

        public BillingInfo BillingInfo { get; set; }
    }

    public class Expiry
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
