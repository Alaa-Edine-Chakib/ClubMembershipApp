using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.Views
{
    public class UserLoginView : IView
    {
    
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
           _loginUser = login;
        }



        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();
            Console.WriteLine("Entrez votre adresse e-mail:");
            string email = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe:");
            string password = Console.ReadLine();
            User user = _loginUser.Login(email, password);

            if (user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Danger);
                Console.WriteLine("Adresse e-mail ou mot de passe incorrect.");
                CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Default);
                Console.ReadKey();
                RunView();
            }

        }
    }
}
