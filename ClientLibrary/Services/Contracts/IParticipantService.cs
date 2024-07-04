
using BaseLibrary.Entities;
using BaseLibrary.Responses;

namespace ClientLibrary.Services.Contracts
{
    public interface IParticipantService
    {
        Task<List<Participant>> GetAll(string baseUrl);
        Task<Participant> GetById(int trainingProgramId, int employeeId, string baseUrl);
        Task<List<Participant>> GetAllEmployee(int trainingProgramId, string baseUrl);
        Task<List<Participant>> GetAllTrainingProgram(int employeeId, string baseUrl);
        Task<GeneralResponse> Insert(Participant item, string baseUrl);
        Task<GeneralResponse> DeleteById(int trainingProgramId, int employeeId, string baseUrl);
    }
}
