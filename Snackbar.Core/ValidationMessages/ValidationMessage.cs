using System;
using System.Collections.Generic;
using System.Text;

namespace Snackbar.Core.ValidationMessages
{
    public static class ValidationMessage
    {
        public const string IsRequired = "{0} is required..";

        public const string HasMaxLength = "{0} has a maximum length of {1}..";

        public const string HasMinLength = "{0} has a minimum length of {1}..";

        public const string HasStringLength = "{0} needs a length between {1} and {2} chracters..";
    }
}
