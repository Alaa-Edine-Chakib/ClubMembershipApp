using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidationAPI
{
    public static class  CommonRegularExpressionValidationPatterns
    {
        public const string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string QuebecPhoneNumberPattern = @"^(\d{3}-\d{3}-\d{4})$";
        public const string QuebecPostalCodePattern = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$";
        public const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
    }
}
