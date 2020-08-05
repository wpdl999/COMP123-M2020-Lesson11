using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_M2020_Lesson11
{
    public class Contact
    {
        // PUBLIC PROPERTIES
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }

        // CONSTRUCTOR
        public Contact(string frist_name = "", string last_name = "", string email_address = "", string contact_number = "")
        {
            FirstName = frist_name;
            LastName = last_name;
            EmailAddress = email_address;
            ContactNumber = contact_number;
        }
    }
}
