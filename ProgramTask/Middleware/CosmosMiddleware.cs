using Microsoft.Azure.Cosmos;

namespace ProgramTask.Middleware
{
    public class CosmosMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;

        private bool _hasRun = false;
        public CosmosMiddleware(RequestDelegate next, CosmosClient cosmosClient, IConfiguration configuration)
        {
            _next = next;
            _cosmosClient = cosmosClient;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!_hasRun)
            {
                _hasRun = true;
                string questionContainerId = "questions";
                string programContainerId = "programs";
                string clientContainerId = "clients";

                var databaseName = _configuration["CosmoSettings:DatabaseName"];

                var db = await _cosmosClient.CreateDatabaseIfNotExistsAsync(id: databaseName);

                await db.Database.CreateContainerIfNotExistsAsync(questionContainerId, "/id", 400);
                await db.Database.CreateContainerIfNotExistsAsync(programContainerId, "/id", 400);
                await db.Database.CreateContainerIfNotExistsAsync(clientContainerId, "/id", 400);
            }

            await _next(context);
        }
    }
}
