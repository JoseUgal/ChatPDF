using Codefastly.ChatPDF.Domain.Shared;

namespace Codefastly.ChatPDF.Domain.Errors;

public static class DomainErrors
{
    public static class Member
    {
        public static readonly Func<Guid, Error> NotFound = id => new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found."
        );

        public static readonly Error FirstNameEmpty = new(
            "Member.FirstNameEmpty",
            "The member first name is empty"
        );

        public static readonly Error FirstNameTooLong = new(
            "Member.FirstNameTooLong",
            "The member first name is too long"
        );

        public static readonly Error LastNameEmpty = new(
            "Member.LastNameEmpty",
            "The member last name is empty"
        );

        public static readonly Error LastNameTooLong = new(
            "Member.FirstNameTooLong",
            "The member last name is too long"
        );

        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use"
        );

        public static readonly Error EmailEmpty = new(
            "Member.EmailEmpty",
            "The member email is empty"
        );

        public static readonly Error EmailTooLong = new(
            "Member.EmailTooLong",
            "The member email is too long"
        );

        public static readonly Error EmailInvalidFormat = new(
            "Member.EmailInvalidFormat",
            "The member email format is invalid"
        );
    }
}