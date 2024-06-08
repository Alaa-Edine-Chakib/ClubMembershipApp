using ClubMembershipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubMembershipApp.FieldValidators;
using System.Threading.Tasks;
using static ClubMembershipApp.FieldValidators.FieldConstants;

namespace ClubMembershipApp.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string email, string password)
        {
            User user = null;

            using (var dbContext = new ClubMembershipDbContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.Email.ToLower().Trim() == email.ToLower().Trim() && u.Password.Equals(password));
            }
            return user;
        }
    }
}
