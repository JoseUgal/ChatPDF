using Codefastly.ChatPDF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Codefastly.ChatPDF.Extensions.DependencyInjection;

public static class Persistence
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultDatabase");

        if (connectionString is null)
        {
            throw new ArgumentNullException(connectionString, "Connection string is null");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString, sql =>
                sql.MigrationsAssembly(AssemblyReference.Assembly.FullName)
            )
        );
    }
}