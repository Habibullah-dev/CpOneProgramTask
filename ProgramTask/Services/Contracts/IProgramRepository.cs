using ProgramTask.Dtos.Requests;
using ProgramTask.Models;

namespace ProgramTask.Services.Contracts
{
    public interface IProgramRepository
    {
        Task<EmployerProgram> AddProgramAsync(EmployerProgramRequestDto item);
        Task<EmployerProgram?> GetEmployerProgramAsync(string id);
        Task<Client?> SaveClientProgramInfoAsync(string programId, PersonalInfo info);
    }
}
