using Codefastly.ChatPDF.Domain.Entities;
using Codefastly.ChatPDF.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Codefastly.ChatPDF.Persistence.Repositories;

public sealed class MemberRepository(ApplicationDbContext context) : IMemberRepository
{
    public async Task<IEnumerable<Member>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Members.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        var memberIsFounded = await context.Members.AnyAsync(
            member => member.Email == email,
            cancellationToken
        );

        return !memberIsFounded;
    }

    public async Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Members.FirstOrDefaultAsync(
            member => member.Id == id,
            cancellationToken
        );
    }

    public void Add(Member member) => context.Members.Add(member);

    public void Update(Member member) => context.Update(member);
}