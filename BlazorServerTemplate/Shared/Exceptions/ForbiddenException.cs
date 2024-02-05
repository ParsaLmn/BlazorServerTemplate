using Microsoft.Extensions.Localization;
using System.Net;
using System.Runtime.Serialization;

namespace Shared.Exceptions;

[Serializable]
public class ForbiddenException : RestException
{
    public ForbiddenException()
        : base("دسترسی ممنوع است")
    {
    }

    public ForbiddenException(string message)
        : base(message)
    {
    }

    public ForbiddenException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public ForbiddenException(LocalizedString message)
        : base(message)
    {
    }

    public ForbiddenException(LocalizedString message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected ForbiddenException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}
