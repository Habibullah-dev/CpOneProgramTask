using Microsoft.Azure.Cosmos;
using ProgramTask.Dtos.Requests;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

namespace ProgramTask.Services.Repos
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IQuestionRepository _questionRepository;
        private readonly Container _programContainer;
        private readonly Container _clientContainer;

        public ProgramRepository(CosmosClient cosmosClient, IConfiguration configuration, IQuestionRepository questionRepository)
        {
            _configuration = configuration;
            _questionRepository = questionRepository;
            var dbName = _configuration["CosmoSettings:DatabaseName"];

            string programContainerId = "programs";
            string clientContainerId = "clients";

            _programContainer = cosmosClient.GetContainer(dbName, programContainerId);
            _clientContainer = cosmosClient.GetContainer(dbName, clientContainerId);
        }


        public async Task<EmployerProgram> AddProgramAsync(EmployerProgramRequestDto item)
        {
            List<BaseQuestion> customQuestions = new List<BaseQuestion>();

            foreach (string id in item.AdditionalQuestionId)
            {
                try
                {
                    var question = await _questionRepository.GetQuestionAsync(id);

                    if (question != null)
                    {
                        customQuestions.Add(question);

                    }

                }
                catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    continue;
                }

            }


            EmployerProgram program = new EmployerProgram()
            {
                Id = Guid.NewGuid().ToString(),
                Title = item.Title,
                Description = item.Description,
                PersonalInfo = new PersonalInfo()
                {
                    Id = Guid.NewGuid().ToString(),

                    FirstName = new ParagraphQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = true,
                        Question = "FirstName",
                        IsHidden = false,
                    },
                    LastName = new ParagraphQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = true,
                        Question = "LastName",
                        IsHidden = false,
                    },
                    Email = new ParagraphQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = true,
                        Question = "Email",
                        IsHidden = false,
                    },

                    Phone = new ParagraphQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsPhoneInternal,
                        Question = "Phone(without dial code)",
                        IsHidden = item.IsPhoneHidden,
                    },
                    Nationality = new DropdownQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsNationalityInternal,
                        Question = "Nationality",
                        IsHidden = item.IsPhoneHidden,
                        Choices = ["Nigeria", "China", "Russia", "Korean"]
                    },
                    IdNumber = new NumberQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsIdNumberInternal,
                        Question = "Nationality",
                        IsHidden = item.IsIdNumberHidden,
                    },
                    CurrentResidence = new DropdownQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsCurrentResidenceInternal,
                        Question = "Current Residence",
                        IsHidden = item.IsCurrentResidenceHidden,
                        Choices = ["Nigeria", "China", "Russia", "Korean"]
                    },
                    DateOfBirth = new ParagraphQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsGenderInternal,
                        Question = "Date Of Birth",
                        IsHidden = item.IsGenderHidden,
                    },
                    Gender = new DropdownQuestion()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsMandatory = !item.IsGenderInternal,
                        Question = "Current Residence",
                        IsHidden = item.IsGenderHidden,
                        Choices = ["Male", "Female"]
                    },
                    AdditionalQuestions = customQuestions
                },



            };

            ItemResponse<EmployerProgram> itemResponse = await _programContainer.CreateItemAsync(program, new PartitionKey(program.Id));

            return itemResponse.Resource;
        }

        public async Task<EmployerProgram?> GetEmployerProgramAsync(string id)
        {
            try
            {
                ItemResponse<EmployerProgram> response = await _programContainer.ReadItemAsync<EmployerProgram>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Client?> SaveClientProgramInfoAsync(string programId, PersonalInfo info)
        {
            Client client = new() { Id = Guid.NewGuid().ToString(), PersonalInfo = info, ProgramId = programId };

            ItemResponse<Client> itemResponse = await _clientContainer.CreateItemAsync(client, new PartitionKey(client.Id));

            return itemResponse.Resource;


        }

    }
}
