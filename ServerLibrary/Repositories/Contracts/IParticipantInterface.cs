
using BaseLibrary.Entities;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IParticipantInterface
    {
        Task<List<Participant>> GetAll();
        Task<Participant> GetById(int trainingProgramId, int employeeId);
        Task<List<Participant>> GetAllByTrainingProgramId(int trainingProgramId);
        Task<List<Participant>> GetAllByEmployeeId(int employeeId);
        Task<GeneralResponse> Insert(Participant item);
        Task<GeneralResponse> DeleteById(int trainingProgramId, int employeeId);
    }
}
