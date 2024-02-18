using Codefastly.ChatPDF.Domain.Errors;
using Codefastly.ChatPDF.Domain.Primitives;
using Codefastly.ChatPDF.Domain.Shared;

namespace Codefastly.ChatPDF.Domain.Entities;

public sealed class Member : Entity
{
    public static readonly int FirstNameMaxLength = 50;

    public static readonly int LastNameMaxLength = 50;

    public static readonly int EmailMaxLength = 255;

    public static Result<Member> Create(Guid id, string email, string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Member>(DomainErrors.Member.EmailEmpty);
        }

        if (email.Length > EmailMaxLength)
        {
            return Result.Failure<Member>(DomainErrors.Member.EmailTooLong);
        }

        if (email.Split('@').Length != 2)
        {
            return Result.Failure<Member>(DomainErrors.Member.EmailInvalidFormat);
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Member>(DomainErrors.Member.FirstNameEmpty);
        }

        if (firstName.Length > FirstNameMaxLength)
        {
            return Result.Failure<Member>(DomainErrors.Member.FirstNameTooLong);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Member>(DomainErrors.Member.LastNameEmpty);
        }

        if (lastName.Length > LastNameMaxLength)
        {
            return Result.Failure<Member>(DomainErrors.Member.LastNameTooLong);
        }

        var member = new Member(id, email, firstName, lastName);

        // TODO: Raise domain event

        return member;
    }

    public Result ChangeName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Member>(DomainErrors.Member.FirstNameEmpty);
        }

        if (firstName.Length > FirstNameMaxLength)
        {
            return Result.Failure<Member>(DomainErrors.Member.FirstNameTooLong);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Member>(DomainErrors.Member.LastNameEmpty);
        }

        if (lastName.Length > LastNameMaxLength)
        {
            return Result.Failure<Member>(DomainErrors.Member.LastNameTooLong);
        }

        if (!firstName.Equals(firstName) || !lastName.Equals(lastName))
        {
            // TODO: Raise domain event
        }

        FirstName = firstName;
        LastName = lastName;

        return Result.Success();
    }

    public string Email { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    private Member()
    {
    }

    private Member(Guid id, string email, string firstName, string lastName) : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}