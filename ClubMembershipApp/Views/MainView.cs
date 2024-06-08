using ClubMembershipApp.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.Views
{
    public class MainView : IView
    {

        IFieldValidator IView.FieldValidator => null;

        IView _registerView;
        IView _loginView;

        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;

        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("C. Connexion");
            Console.WriteLine("I. Inscription");

            ConsoleKey consoleKey = Console.ReadKey().Key;

            if(consoleKey == ConsoleKey.C)
            {
                RunUserLoginView();

            }
            else if(consoleKey == ConsoleKey.I)
            {
                RunUserRegisterView();
                RunUserLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Au Revoir");
                Console.ReadKey();
            }


        }

        private void RunUserRegisterView()
        {
            _registerView.RunView();
        }

        private void RunUserLoginView()
        {
            _loginView.RunView();
        }
    }
    
    }

