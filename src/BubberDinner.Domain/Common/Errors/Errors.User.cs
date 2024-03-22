﻿using ErrorOr;

namespace BubberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code:"User.DuplicateEmail", description:"Email is already in user");
        }
    }
}
