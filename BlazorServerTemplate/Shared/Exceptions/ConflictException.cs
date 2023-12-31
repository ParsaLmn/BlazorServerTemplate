﻿using Microsoft.Extensions.Localization;
using System.Net;
using System.Runtime.Serialization;

namespace Shared.Exceptions;

[Serializable]
public class ConflictException : RestException
{
    public ConflictException()
        : this("خطای Conflic رخ داده است")
    {
    }

    public ConflictException(string message)
        : base(message)
    {
    }

    public ConflictException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public ConflictException(LocalizedString message)
        : base(message)
    {
    }

    public ConflictException(LocalizedString message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected ConflictException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
