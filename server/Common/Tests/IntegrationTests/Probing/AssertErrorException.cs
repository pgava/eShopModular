﻿namespace EShopModular.Common.IntegrationTests.Probing;

public class AssertErrorException : Exception
{
    public AssertErrorException(string message)
        : base(message)
    {
    }
}