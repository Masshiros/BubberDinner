﻿using ErrorOr;

namespace BubberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Auth
        {
            public static Error InvalidCredential => Error.Validation(code: "Auth.InvalidCred", description: "Invalid Credentials");
        }
    }
}
