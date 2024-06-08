using FieldValidationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidator
    {
        const int FirstName_MinLength = 2;
        const int FirstName_MaxLength = 50;
        const int LastName_MinLength = 2;
        const int LastName_MaxLength = 50;

        delegate bool EmailExistsDel(string emailAdress);

        FieldValidorDelegate _fieldValidatorDel = null;

        RequiredFieldValidatorDelegate _requiredFieldValidDel = null;
        StringLengthFieldValidatorDelegate _stringLengthFieldValidDel = null;
        DateValidatorDelegate _dateValidDel = null;
        PatternValidatorDelegate _patterMatchValidDel = null;
        CompareValidatorDelegate _compareValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)               
                    _fieldArray = new string[(Enum.GetValues(typeof(FieldConstants.UserRegistrationFields))).Length];
                return _fieldArray;
                
            }
        }

        public FieldValidorDelegate ValidatorDel => _fieldValidatorDel;

       
        public UserRegistrationValidator()
        {

        }

        public void InitializeFieldValidators()
        {
            _fieldValidatorDel = new FieldValidorDelegate(ValidField);
            _requiredFieldValidDel = CommonFieldValidatorFunctions.RequiredFieldValid;
            _stringLengthFieldValidDel = CommonFieldValidatorFunctions.StringLengthFieldValid;
            _dateValidDel = CommonFieldValidatorFunctions.DateValid;
            _patterMatchValidDel = CommonFieldValidatorFunctions.PatternValid;
            _compareValidDel = CommonFieldValidatorFunctions.CompareValid;
         
        }

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";
            FieldConstants.UserRegistrationFields userRegistrationFields = (FieldConstants.UserRegistrationFields)fieldIndex;
            switch (userRegistrationFields)
            {
                case FieldConstants.UserRegistrationFields.FirstName:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthFieldValidDel(fieldValue, FirstName_MinLength, FirstName_MaxLength)) ? $"La longueur de la valeur doit être comprise entre {FirstName_MinLength} et {FirstName_MaxLength} pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.LastName:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthFieldValidDel(fieldValue, LastName_MinLength, LastName_MaxLength)) ? $"La longueur de la valeur doit être comprise entre {LastName_MinLength} et {LastName_MaxLength} pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.Password:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage =(fieldInvalidMessage == "" && !_patterMatchValidDel(fieldValue,CommonRegularExpressionValidationPatterns.PasswordPattern)) ? $"La valeur doit contenir au moins une lettre majuscule, une lettre minuscule, un chiffre et un caractère spécial pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.PasswordConfirm:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationFields.Password])) ? $"La valeur doit être identique à celle du champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), FieldConstants.UserRegistrationFields.Password)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.DateOfBirth:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"La valeur doit être une date valide pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.PhoneNumber:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patterMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.QuebecPhoneNumberPattern)) ? $"La valeur doit être un numéro de téléphone valide pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationFields.AdressFirstLine:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationFields.AdressSecondLine:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationFields.AdressCity:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationFields.AdressPostCode:
                    fieldInvalidMessage = (!_requiredFieldValidDel(fieldValue)) ? $"Vous devez entrer une valeur pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patterMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.QuebecPostalCodePattern)) ? $"La valeur doit être un code postal valide pour ce champs:{Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("Invalid field index");



            }

            return (fieldInvalidMessage == "");

        }





    }
}
