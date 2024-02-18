using Codefastly.ChatPDF.Domain.Entities;
using Codefastly.ChatPDF.Domain.Errors;
using Codefastly.ChatPDF.Domain.Repositories;
using Codefastly.ChatPDF.Domain.Shared;

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

    public async Task<Result> CreateMember(
        Guid id, string email, string firstName, string lastName,
        CancellationToken cancellationToken = default
    )
    {
        if (!await memberRepository.IsEmailUniqueAsync(email, cancellationToken))
        {
            return Result.Failure(DomainErrors.Member.EmailAlreadyInUse);
        }

        var memberResult = Member.Create(id, email, firstName, lastName);

        if (memberResult.IsFailure)
        {
            return Result.Failure(memberResult.Error);
        }

        memberRepository.Add(memberResult.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}