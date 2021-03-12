using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.entities
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            return FirstName.Equals(((User)obj).FirstName) && LastName.Equals(((User)obj).LastName) && Email.Equals(((User)obj).Email) &&
                Phone.Equals(((User)obj).Phone);
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Email + " " + this.Phone;
        }

    }
}
