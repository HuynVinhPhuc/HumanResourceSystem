
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string CivilId { get; set; } = string.Empty;
        [Required]
        public string FileNumber { get; set; } = string.Empty;
        [Required]
        public string JobName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
        public string? Other { get; set; }

        // Many to one relationship with Branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
        // Many to one relationship with Town
        public Town? Town { get; set; }
        public int TownId { get; set;}

        // Many to many relationship with TrainingProgram through Participant
        [JsonIgnore]
        public List<Participant>? Participants { get; set; }

        // One-to-many relationship with PeriodicEvaluation
        [JsonIgnore]
        public List<PeriodicEvaluation>? PeriodicEvaluations { get; set; }
    }
}
