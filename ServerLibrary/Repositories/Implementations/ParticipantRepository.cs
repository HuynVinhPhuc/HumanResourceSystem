
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class ParticipantRepository(AppDbContext appDbContext) : IParticipantInterface
    {
        public async Task<GeneralResponse> DeleteById(int trainingProgramId, int employeeId)
        {
            var item = await appDbContext.Participants
                .FirstOrDefaultAsync(p => p.TrainingProgramId == trainingProgramId && p.EmployeeId == employeeId);
            if (item is null) return NotFound();

            appDbContext.Participants.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Participant>> GetAll()
        {
            var participants = await appDbContext.Participants
                .AsNoTracking()
                .Include(p => p.TrainingProgram)
                .Include(p => p.Employee)
                .ToListAsync();

            return participants;
        }

        public async Task<List<Participant>> GetAllByTrainingProgramId(int trainingProgramId)
        {
            var participants = await appDbContext.Participants
                .AsNoTracking()
                .Include(p => p.TrainingProgram)
                .Include(p => p.Employee)
                .Where(p => p.TrainingProgramId == trainingProgramId)
                .ToListAsync();

            return participants;
        }

        public async Task<List<Participant>> GetAllByEmployeeId(int employeeId)
        {
            var participants = await appDbContext.Participants
                .AsNoTracking()
                .Include(p => p.TrainingProgram)
                .Include(p => p.Employee)
                .Where(p => p.EmployeeId == employeeId)
                .ToListAsync();

            return participants;
        }

        public async Task<Participant> GetById(int trainingProgramId, int employeeId)
        {
            var participant = await appDbContext.Participants
                .Include(p => p.TrainingProgram)
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.TrainingProgramId == trainingProgramId && p.EmployeeId == employeeId);

            return participant!;
        }

        public async Task<GeneralResponse> Insert(Participant item)
        {
            appDbContext.Participants.Add(item);
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry participant not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
