using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace HackathonWebAPI
{
    public class DynamoDbContext
    {
        private readonly DynamoDBContext _context;

        public DynamoDbContext()
        {
            var config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var credentials = new EnvironmentVariablesAWSCredentials();
            var client = new AmazonDynamoDBClient(credentials, config);

            _context = new DynamoDBContext(client);
        }

        public async Task SaveAsync<T>(T transaction)
        {
            await _context.SaveAsync(transaction);
        }

        public async Task<T> LoadAsync<T>(string hashKey, string rangeKey)
        {
            return await _context.LoadAsync<T>(hashKey, rangeKey);
        }

        public async Task DeleteAsync<T>(T transaction)
        {
            await _context.DeleteAsync(transaction);
        }
    }
}
