using System.Runtime.Serialization;

namespace Domain.Exceptions.EmailPasswordManagerExceptions;
public class EmailExistsException : Exception
{
    public EmailExistsException() : base()
    {
    }

    protected EmailExistsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public EmailExistsException(string? message) : base(message)
    {
    }

    public EmailExistsException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
