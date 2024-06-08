using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.Views
{
    public class WelcomeUserView:IView
    {
        User _user = null;

        public WelcomeUserView(User user)
        {
            _user = user;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
           CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Sucess);
            Console.WriteLine($"Bienvenue {_user.FirstName} {_user.LastName}");
            CommonOutputFormat.ChangeFontColor(CommonOutputFormat.FontTheme.Default);
            Console.ReadKey();
        }
    }
}
