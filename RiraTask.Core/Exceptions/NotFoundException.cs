﻿namespace RiraTask.Core.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message)
    {
        StatusCode = System.Net.HttpStatusCode.NotFound;
    }
}