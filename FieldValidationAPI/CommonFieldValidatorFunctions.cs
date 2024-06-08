using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidationAPI
{
    public delegate bool RequiredFieldValidatorDelegate(string field);
    public delegate bool StringLengthFieldValidatorDelegate(string field, int minLength, int maxLength);
    public delegate bool DateValidatorDelegate(string field, out DateTime validDateTime);
    public delegate bool PatternValidatorDelegate(string field, string pattern);
    public delegate bool CompareValidatorDelegate (string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFunctions
    {
        private static RequiredFieldValidatorDelegate _requiredFieldValidatorDelegate = null;
        private static StringLengthFieldValidatorDelegate _stringLengthFieldValidatorDelegate = null;
        private static DateValidatorDelegate _dateValidatorDelegate = null;
        private static PatternValidatorDelegate _patternValidatorDelegate = null;
        private static CompareValidatorDelegate _compareValidatorDelegate = null;

        public static RequiredFieldValidatorDelegate RequiredFieldValid
        {
            get
            {
                if (_requiredFieldValidatorDelegate == null)
                {
                    _requiredFieldValidatorDelegate = new RequiredFieldValidatorDelegate(RequiredFieldValidator);
                }
                return _requiredFieldValidatorDelegate;
            }
        }

        public static StringLengthFieldValidatorDelegate StringLengthFieldValid
        {
            get
            {
                if (_stringLengthFieldValidatorDelegate == null)
                {
                    _stringLengthFieldValidatorDelegate = new StringLengthFieldValidatorDelegate(StringLengthFieldValidator);
                }
                return _stringLengthFieldValidatorDelegate;
            }
        }

        public static DateValidatorDelegate DateValid
        {
            get
            {
                if (_dateValidatorDelegate == null)
                {
                    _dateValidatorDelegate = new DateValidatorDelegate(DateValidator);
                }
                return _dateValidatorDelegate;
            }
        }

        public static PatternValidatorDelegate PatternValid
        {
            get
            {
                if (_patternValidatorDelegate == null)
                {
                    _patternValidatorDelegate = new PatternValidatorDelegate(PatternValidator);
                }
                return _patternValidatorDelegate;
            }
        }

        public static CompareValidatorDelegate CompareValid
        {
            get
            {
                if (_compareValidatorDelegate == null)
                {
                    _compareValidatorDelegate = new CompareValidatorDelegate(CompareValidator);
                }
                return _compareValidatorDelegate;
            }
        }



        private static bool RequiredFieldValidator(string field)
        {
            return !string.IsNullOrEmpty(field);
        }

        private static bool StringLengthFieldValidator(string field, int minLength, int maxLength)
        {
            return field.Length >= minLength && field.Length <= maxLength;
        }

        private static bool DateValidator(string field, out DateTime validDateTime)
        {
            return DateTime.TryParse(field, out validDateTime);
        }

        private static bool PatternValidator(string field, string pattern)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(field, pattern);
        }

        private static bool CompareValidator(string fieldVal, string fieldValCompare)
        {
            return fieldVal.Equals(fieldValCompare);
        }



    }
}
