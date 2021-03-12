using Bogus;
using SpecFlowDreanLotteryHome.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.services
{
    class AutogeneratorService
    {
        private Faker Faker = new Faker();

        public string GenerateTitle()
        {        
            return Faker.Address.FullAddress();
        }
        public User GetUser()
        {
            User user = new User();
            user.FirstName = Faker.Name.FirstName();
            user.LastName = Faker.Name.LastName();
            user.Phone = Faker.Phone.PhoneNumber().Replace("-", "").Replace("(", "").Replace(")", "").Replace("x", "").Replace(" ", "").Replace(".", "");
            user.Email = Faker.Person.Email.ToLower();
            user.Country = "Australia";
            return user;
        }
    }
}
