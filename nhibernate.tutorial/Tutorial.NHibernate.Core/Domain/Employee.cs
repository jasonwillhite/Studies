using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.NHibernate.Core.Domain
{
    public class Employee
    {
        public string EmployeeNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }

        public Address ResidentialAddress { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public ICollection<Benefit> Benefits { get; set; }
    }
}
