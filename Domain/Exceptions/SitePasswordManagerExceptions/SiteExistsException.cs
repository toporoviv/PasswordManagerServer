using System.Runtime.Serialization;

namespace Domain.Exceptions.SitePasswordManagerExceptions;
public class SiteExistsException : Exception
{
    public SiteExistsException() : base()
    {
    }

    protected SiteExistsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public SiteExistsException(string? message) : base(message)
    {
    }

    public SiteExistsException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
