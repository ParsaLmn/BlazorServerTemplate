﻿using Microsoft.Extensions.Localization;
using System.Net;
using System.Runtime.Serialization;

namespace Shared.Exceptions;

[Serializable]
public class RestException : KnownException
{
    public RestException()
        : base("خطا در انجام عملیات")
    {
    }

    public RestException(string message)
        : base(message)
    {
    }

    public RestException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public RestException(LocalizedString message)
        : base(message)
    {
    }

    public RestException(LocalizedString message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected RestException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public virtual HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}
