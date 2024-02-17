using Codefastly.ChatPDF.Domain.Repositories;
using Codefastly.ChatPDF.Persistence;
using Codefastly.ChatPDF.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Codefastly.ChatPDF.Extensions.DependencyInjection;

public static class Persistence
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IMemberRepository, MemberRepository>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(
                configuration.FindDatabaseConnectionString("DefaultDatabase"),
                sql =>
                    sql.MigrationsAssembly(AssemblyReference.Assembly.FullName)
            )
        );
    }

    private static string FindDatabaseConnectionString(this IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString(name);

        if (connectionString is null)
        {
            throw new ArgumentNullException(
                connectionString,
                "Connection string is null with name: " + name
            );
        }

        return connectionString;
    }
}