using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.Views
{
    internal class RegistrationView : IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;
        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public RegistrationView(IFieldValidator fieldValidator, IRegister register)
        {
            _fieldValidator = fieldValidator;
            _register = register;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegisterHeading();
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.Email] = GetInputFromUser(FieldConstants.UserRegistrationFields.Email, "Entrez votre courriel");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationFields.FirstName, "Entrez votre prénom");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.LastName] = GetInputFromUser(FieldConstants.UserRegistrationFields.LastName, "Entrez votre nom de famille");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.Password] = GetInputFromUser(FieldConstants.UserRegistrationFields.Password, "Entrez votre mot de passe");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.PasswordConfirm] = GetInputFromUser(FieldConstants.UserRegistrationFields.PasswordConfirm, "Confirmez votre mot de passe");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationFields.DateOfBirth, "Entrez votre date de naissance");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.PhoneNumber] = GetInputFromUser(FieldConstants.UserRegistrationFields.PhoneNumber, "Entrez votre numéro de téléphone");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AdressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationFields.AdressFirstLine, "Entrez votre adresse");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AdressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationFields.AdressSecondLine, "Entrez votre adresse");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AdressCity] = GetInputFromUser(FieldConstants.UserRegistrationFields.AdressCity, "Entrez votre ville");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AdressPostCode] = GetInputFromUser(FieldConstants.UserRegistrationFields.AdressPostCode, "Entrez votre code postal");
            RegisterUser();
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationFields field, string promptText)
        {
            string fieldValue = string.Empty;

            do
            {
                Console.WriteLine(promptText);
                fieldValue = Console.ReadLine();
            }
            while (!FieldValid(field, fieldValue));
            return fieldValue;
        }

        private bool FieldValid(FieldConstants.UserRegistrationFields field, string fieldValue)
        {
            if(!_fieldValidator.Validator((int)field, fieldValue,_fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Default);
                return false;
            }
            return true;
        }
        private void RegisterUser()
        {
             _register.Register(_fieldValidator.FieldArray);
             CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Sucess);
            Console.WriteLine("Inscription réussie, Appuyez sur n'importe quel touche pour vous connecter");
            CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Default);
            Console.ReadKey();
        }
    }

}
