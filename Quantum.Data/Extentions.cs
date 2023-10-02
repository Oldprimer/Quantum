using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quantum.Data.Context;
using Quantum.Data.Interfaces;
using Quantum.Data.Model;
using Quantum.Data.Repositories;
using Quantum.Data.Services;

namespace Quantum.Data
{
    public static class Extentions
    {
        public static IServiceCollection AddData(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IRepository<Note>, NoteRepository>();
            serviceDescriptors.AddScoped<INoteService, NoteService>();
            return serviceDescriptors;
        }
        public static IServiceCollection AddPostgreSql(this IServiceCollection serviceDescriptors, string connectionString)
        {
            return serviceDescriptors.AddScoped<PostgreSqlContext>(_ =>
            {
                var options = new DbContextOptionsBuilder();
                options.UseNpgsql(connectionString ?? throw new NullReferenceException(
                                             $"Connection string is not got from appsettings.json"));
                return new PostgreSqlContext(options.Options);
            });
        }
    }
}
