using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.FieldValidators
{
    public class FieldConstants
    {
        public enum UserRegistrationFields
        {
            FirstName,
            LastName,
            Password,
            DateOfBirth,
            PhoneNumber,
            AdressFirstLine,
            AdressSecondLine,
            AdressCity,
            AdressPostCode,
            PasswordConfirm,
            Email
        }
    }
}
