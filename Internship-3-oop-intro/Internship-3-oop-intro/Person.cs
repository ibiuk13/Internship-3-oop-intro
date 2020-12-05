using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_3_oop_intro
{
    public class Person
    {
        public Person(string firstname, string lastname, string oib, string phonenumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Oib = oib;
            PhoneNumber = phonenumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string PhoneNumber { get; set; }
    }
}
