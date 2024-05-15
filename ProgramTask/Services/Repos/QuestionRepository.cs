using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Newtonsoft.Json;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

namespace ProgramTask.Services.Repos
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Container _quesionContainer;

        public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _configuration = configuration;

            var dbName = _configuration["CosmoSettings:DatabaseName"];
            string questionContainerId = "questions";

            _quesionContainer = cosmosClient.GetContainer(dbName, questionContainerId);

        }

        public async Task<IEnumerable<BaseQuestion>> GetQuestionsAsync()
        {
            var query = _quesionContainer.GetItemLinqQueryable<BaseQuestion>().ToFeedIterator();

            var questions = new List<BaseQuestion>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<BaseQuestion?> GetQuestionAsync(string id)
        {

            var response = await _quesionContainer.ReadItemAsync<dynamic>(id, new PartitionKey(id));

            string type = response.Resource.type;

            try
            {
                switch (type)
                {
                    case "Dropdown":
                        return JsonConvert.DeserializeObject<DropdownQuestion>(response.Resource.ToString());
                    case "Paragraph":
                        return JsonConvert.DeserializeObject<ParagraphQuestion>(response.Resource.ToString());
                    case "Number":
                        return JsonConvert.DeserializeObject<NumberQuestion>(response.Resource.ToString());
                    case "YesOrNo":
                        return JsonConvert.DeserializeObject<YesOrNoQuestion>(response.Resource.ToString());
                    case "MultiChoice":
                        return JsonConvert.DeserializeObject<MultiChoiceQuestion>(response.Resource.ToString());
                    default:
                        return null;
                }

            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task AddQuestionAsync(BaseQuestion item)
        {
            ItemResponse<BaseQuestion> itemResponse = await _quesionContainer.CreateItemAsync(item, new PartitionKey(item.Id));

        }

        public async Task UpdateItemAsync(string id, BaseQuestion item)
        {
            await _quesionContainer.UpsertItemAsync<BaseQuestion>(item, new PartitionKey(id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await _quesionContainer.DeleteItemAsync<BaseQuestion>(id, new PartitionKey(id));
        }
    }
}
