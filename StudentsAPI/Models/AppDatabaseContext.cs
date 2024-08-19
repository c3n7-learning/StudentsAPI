using Microsoft.EntityFrameworkCore;

namespace StudentsAPI.Models
{
    public class AppDatabaseContext: DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options): base(options) { }

        public DbSet<ClassStream> ClassStreams { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
