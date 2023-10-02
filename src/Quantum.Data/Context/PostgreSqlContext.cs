using Microsoft.EntityFrameworkCore;
using Quantum.Data.Configuration;
using Quantum.Data.Model;

namespace Quantum.Data.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Note> Notes { get; set; }
    }
}
