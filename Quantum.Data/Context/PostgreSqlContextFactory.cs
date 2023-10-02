using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Quantum.Data.Context
{
    public class PostgreSqlContextFactory : IDesignTimeDbContextFactory<PostgreSqlContext>
    {
        public PostgreSqlContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<PostgreSqlContext>();
            var connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=123456";
            optionBuilder.UseNpgsql(connectionString ?? throw new NullReferenceException(
                                         $"Connection string is not got from environment {nameof(connectionString)}"));
            return new PostgreSqlContext(optionBuilder.Options);
        }
    }
}
