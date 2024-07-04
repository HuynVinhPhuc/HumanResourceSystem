
using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }

        // General Department / Department / Branch
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        // Country / City / Town
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        // Authentication / Role / System Roles
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        // Other / Vacation / Sanction / Doctor / Overtime
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationsTypes { get; set; }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }

        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }

        // Doctor
        public DbSet<Doctor> Doctors { get; set; }

        // Recruitment / Candidate
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        // TrainingProgram / Participant / Instructor
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        //PeriodicEvaluation
        public DbSet<PeriodicEvaluation> PeriodicEvaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the many-to-many relationship between TrainingProgram and Employee through Participant
            modelBuilder.Entity<Participant>()
                .HasKey(p => new { p.TrainingProgramId, p.EmployeeId });

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.TrainingProgram)
                .WithMany(tp => tp.Participants)
                .HasForeignKey(p => p.TrainingProgramId);

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
