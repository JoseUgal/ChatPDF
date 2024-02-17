using Codefastly.ChatPDF.Application.Services;

namespace Codefastly.ChatPDF.Extensions.DependencyInjection;

public static class Application
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<MemberService>();
    }
}