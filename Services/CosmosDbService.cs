using Microsoft.Azure.Cosmos;
using IbasSupportApp.Models;

namespace IbasSupportApp.Services
{
    public class CosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(IConfiguration configuration)
        {
            var connectionString = configuration["CosmosDb:ConnectionString"];
            var databaseName = configuration["CosmosDb:DatabaseName"];
            var containerName = configuration["CosmosDb:ContainerName"];

            var cosmosClient = new CosmosClient(connectionString);
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<SupportMessage> AddSupportMessageAsync(SupportMessage message)
        {
            var response = await _container.CreateItemAsync(message, new PartitionKey(message.category));
            return response.Resource;
        }
        
        public async Task<List<SupportMessage>> GetAllMessagesAsync()
        {
            var results = new List<SupportMessage>();
            var query = _container.GetItemQueryIterator<SupportMessage>("SELECT * FROM c");
            
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }
    }
}