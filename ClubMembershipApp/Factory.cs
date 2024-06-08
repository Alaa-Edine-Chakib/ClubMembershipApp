using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp
{
    public static class  Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator UserRegistrationfieldValidator = new UserRegistrationValidator(register);
            UserRegistrationfieldValidator.InitializeFieldValidators();

            IView registerView = new RegistrationView(UserRegistrationfieldValidator, register);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView);

            return mainView;

        }

    }
}
