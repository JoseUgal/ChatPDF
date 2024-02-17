using Codefastly.ChatPDF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codefastly.ChatPDF.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable(nameof(ApplicationDbContext.Members));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstNam);
        
        builder.Property(x => x.LastName);

        builder.Property(x => x.Email);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}