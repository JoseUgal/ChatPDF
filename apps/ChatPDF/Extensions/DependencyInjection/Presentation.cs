namespace Codefastly.ChatPDF.Extensions.DependencyInjection;

public static class Presentation
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllers().AddApplicationPart(AssemblyReference.Assembly);
    }
}