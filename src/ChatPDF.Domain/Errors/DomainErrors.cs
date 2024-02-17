using Codefastly.ChatPDF.Domain.Shared;

namespace Codefastly.ChatPDF.Domain.Errors;

public static class DomainErrors
{
    public static class Member
    {
        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use"
        );

        public static readonly Func<Guid, Error> NotFound = id => new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found."
        );
    }

    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty"
        );

        public static readonly Error TooLong = new(
            "FirstName.TooLong",
            "First name is too long"
        );
    }

    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name is empty"
        );

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "Last name is too long"
        );
    }
}