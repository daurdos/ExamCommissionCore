using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using Phd.Models;

namespace Phd.Models
{
    public class PhdContext : IdentityDbContext<User>
    {
        public PhdContext(DbContextOptions<PhdContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phd.Models.Faculty> Faculty { get; set; }
        public DbSet<Phd.Models.AcademicDepartment> AcademicDepartment { get; set; }
        public DbSet<Phd.Models.BDirection> BDirection { get; set; }
        public DbSet<Phd.Models.BMajor> BMajor { get; set; }
        public DbSet<Phd.Models.BRStudentGroup> BRStudentGroup { get; set; }
        public DbSet<Phd.Models.BRStudent> BRStudent { get; set; }
        public DbSet<Phd.Models.BRStudentGrade> BRStudentGrade { get; set; }
        public DbSet<Phd.Models.BRStudentDoc> BRStudentDoc { get; set; }
        public DbSet<Phd.Models.StudentDocType> StudentDocType { get; set; }
        public DbSet<Phd.Models.UserActivity> UserActivitiy { get; set; }
        public DbSet<Phd.Models.DictionaryAcademicDegree> DictionaryAcademicDegree { get; set; }
        public DbSet<Phd.Models.DictionaryStatusAvailability> DictionaryStatusAvailability { get; set; }
        public DbSet<Phd.Models.DictionaryStatusConclusion> DictionaryStatusConclusion { get; set; }
        public DbSet<Phd.Models.DictionaryStudyYear> DictionaryStudyYear { get; set; }
        public DbSet<Phd.Models.GradesTable> GradesTable { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}
