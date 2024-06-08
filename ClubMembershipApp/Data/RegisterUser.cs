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
    public class RegisterUser : IRegister
    {
        public bool EmailExiste(string emailAdress)
        {
           bool emailExist = false;
           using (var dbContext = new ClubMembershipDbContext())
            {
                emailExist = dbContext.Users.Any(u => u.Email.ToLower().Trim() == emailAdress.ToLower().Trim());
            }
            return emailExist;
        }

        public bool Register(string[] fields)
        {
            using(var dbContext = new ClubMembershipDbContext())
            {
                User user = new User()
                {
                    Email = fields[(int)UserRegistrationFields.Email],
                    FirstName = fields[(int)UserRegistrationFields.FirstName],
                    LastName = fields[(int)UserRegistrationFields.LastName],
                    Password = fields[(int)UserRegistrationFields.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)UserRegistrationFields.DateOfBirth]),
                    PhoneNumber = fields[(int)UserRegistrationFields.PhoneNumber],
                    AdressFirstLine = fields[(int)UserRegistrationFields.AdressFirstLine],
                    AdressSecondLine = fields[(int)UserRegistrationFields.AdressSecondLine],
                    AdressCity = fields[(int)UserRegistrationFields.AdressCity],
                    AdressPostCode = fields[(int)UserRegistrationFields.AdressPostCode]
                };
                dbContext.Add(user);

                dbContext.SaveChanges();
            }
                return true;
            }
        }
    }

