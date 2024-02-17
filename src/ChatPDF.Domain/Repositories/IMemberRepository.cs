using Codefastly.ChatPDF.Domain.Entities;

namespace Codefastly.ChatPDF.Domain.Repositories;

public interface IMemberRepository
{
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

    Task<IEnumerable<Member>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Member member);

    void Update(Member member);
}