using ProgramTask.Models;

namespace ProgramTask.Services.Contracts
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(BaseQuestion item);
        Task DeleteItemAsync(string id);
        Task<BaseQuestion?> GetQuestionAsync(string id);
        Task<IEnumerable<BaseQuestion>> GetQuestionsAsync();
        Task UpdateItemAsync(string id, BaseQuestion item);
    }
}
