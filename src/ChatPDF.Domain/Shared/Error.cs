namespace Codefastly.ChatPDF.Domain.Shared;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");

    public static implicit operator string(Error error) => error.Code;

    public bool Equals(Error? other)
    {
        if (other is null) return false;

        return Code == other.Code && Message == other.Message;
    }

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}