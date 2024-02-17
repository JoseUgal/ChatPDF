using Codefastly.ChatPDF.Domain.Primitives;

namespace Codefastly.ChatPDF.Domain.Entities;

public sealed class Member : Entity
{
    public static Member Create(Guid id, string email, string firstName, string lastName)
    {
        var member = new Member(id, email, firstName, lastName);

        // TODO: Raise domain event

        return member;
    }

    public void ChangeName(string firstName, string lastName)
    {
        if (!firstName.Equals(firstName) || !lastName.Equals(lastName))
        {
            // TODO: Raise domain event
        }

        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    private Member() {}
    
    private Member(Guid id, string email, string firstName, string lastName) : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}