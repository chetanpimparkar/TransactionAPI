using Amazon.DynamoDBv2.DataModel;

namespace HackathonWebAPI.Models
{
    [DynamoDBTable("Transactions")]
    public class Transaction
    {
        //[DynamoDBHashKey]
        public string? TransactionId { get; set; }

        //[DynamoDBRangeKey]
        public string TripId { get; set; }

        public string? Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Currency { get; set; }

        public Card? Card { get; set; }

        public Point? Points { get; set; }   

        public DateTime DateTime { get; set; }
    }

    public class Point
    {
        public decimal? EquivalentValue { get; set; }
    }
}
