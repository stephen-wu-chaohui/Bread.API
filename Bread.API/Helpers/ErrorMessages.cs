using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.API.Helpers
{
    public static class ErrorMessages
    {
        public const string PasswordEmpty = "PasswordEmpty";
        public const string PasswordLength = "PasswordLength";
        public const string PasswordUppercaseLetter = "PasswordUppercaseLetter";
        public const string PasswordLowercaseLetter = "PasswordLowercaseLetter";
        public const string PasswordDigit = "PasswordDigit";
        public const string PasswordSpecialCharacter = "PasswordSpecialCharacter";
    }
}
