using Codefastly.ChatPDF.Domain.Entities;

namespace Codefastly.ChatPDF.Domain.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Member member);

    void Update(Member member);
}