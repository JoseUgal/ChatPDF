using Codefastly.ChatPDF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codefastly.ChatPDF.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public DbSet<Member> Members { get; init; } = null!;
}