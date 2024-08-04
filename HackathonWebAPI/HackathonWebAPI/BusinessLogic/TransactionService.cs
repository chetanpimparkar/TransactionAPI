using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using HackathonWebAPI.Models;
using HackathonWebAPI.Services;

namespace HackathonWebAPI.BusinessLogic
{
    public class TransactionService : ITransactionService
    {
        private readonly IDynamoDBContext _context;

        public TransactionService(IAmazonDynamoDB dynamoDB)
        {
            _context = new DynamoDBContext(dynamoDB);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.SaveAsync(transaction);
        }

        public async Task<List<Transaction>> GetTransactionsByUserAsync(string tripId)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("TripId", ScanOperator.Equal, tripId)
            };
            return await _context.ScanAsync<Transaction>(conditions).GetRemainingAsync();
        }
    }
}
