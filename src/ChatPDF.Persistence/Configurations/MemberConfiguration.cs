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

        builder.Property(x => x.FirstName)
            .HasMaxLength(Member.FirstNameMaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(Member.LastNameMaxLength)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(Member.EmailMaxLength)
            .IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();
    }
}