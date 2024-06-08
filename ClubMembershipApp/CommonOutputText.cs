using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp
{
    public static class CommonOutputText
    {
        private static string MainHeading
        {
            get
            {
                string heading = "Club Abonnement";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string RegisterHeading
        {
            get
            {
                string heading = "Inscription";
                return $"{MainHeading}{Environment.NewLine}{Environment.NewLine}{new string('-', MainHeading.Length)}";
            }
        }

        private static string LoginHeading
        {
            get
            {
                string heading = "Connexion";
                return $"{MainHeading}{Environment.NewLine}{Environment.NewLine}{new string('-', MainHeading.Length)}";
            }
        }

        public static void WriteMainHeading()
        {
            Console.Clear();
            Console.WriteLine(MainHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteRegisterHeading()
        {
            Console.WriteLine(RegisterHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLoginHeading()
        {
            Console.WriteLine(LoginHeading);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
