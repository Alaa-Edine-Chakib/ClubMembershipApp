using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp
{
    public static class CommonOutputFormat
    {
        public enum FontTheme
        {
            Default,
            Danger,
            Sucess
        }
        public static void ChangeFontColor(FontTheme fontTheme)
        {
          if(fontTheme == FontTheme.Danger)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }else if(fontTheme == FontTheme.Sucess)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
