using Codefastly.ChatPDF.Domain.Repositories;

namespace Codefastly.ChatPDF.Persistence;

public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}