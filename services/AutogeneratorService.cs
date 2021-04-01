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

        public string GenerateStreetAddressTitle()
        {        
            return Faker.Address.StreetAddress();
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

        internal string GenerateNonHouseVehiclePrizeTitle()
        {
            return Faker.Vehicle.Model();
        }
        internal string GenerateAlmostUniqueVehiclePrizeTitle()
        {
            return Faker.Vehicle.Model()+ Faker.Vehicle.Type()+ Faker.Vehicle.Manufacturer()+Faker.Vehicle.Fuel();
        }
    }
}
