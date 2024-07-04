
namespace BaseLibrary.Entities
{
    public class Participant
    {
        // Many to one relationship with TrainingProgram
        public TrainingProgram? TrainingProgram { get; set; }
        public int TrainingProgramId { get; set; }

        // Many to one relationship with Employee
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
