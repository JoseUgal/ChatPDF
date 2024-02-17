using Codefastly.ChatPDF.Domain.Entities;
using Codefastly.ChatPDF.Domain.Errors;
using Codefastly.ChatPDF.Domain.Repositories;

namespace Codefastly.ChatPDF.Application.Services;

public class MemberService(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
{
    public async Task<IEnumerable<Member>> GetMembersAsync(
        CancellationToken cancellationToken = default
    )
    {
        var members = await memberRepository.GetAllAsync(cancellationToken);

        return members;
    }

    public async Task CreateMember(
        Guid id, string email, string firstName, string lastName,
        CancellationToken cancellationToken = default
    )
    {
        if (!await memberRepository.IsEmailUniqueAsync(email, cancellationToken))
        {
            var error = DomainErrors.Member.EmailAlreadyInUse;

            throw new ArgumentException(error.Message, error.Code);
        }

        var member = Member.Create(id, email, firstName, lastName);

        memberRepository.Add(member);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}