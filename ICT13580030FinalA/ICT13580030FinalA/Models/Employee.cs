using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ICT13580030FinalA.Models
{
    public class Employee
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [NotNull]
        public string Gender { get; set; }

        [NotNull]
        public string Section { get; set; }

        [NotNull]
        public int Telephone { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Email { get; set; }

        [NotNull]
        public string Address { get; set; }

        public int Children { get; set; }
        public int Salary { get; set; }

    }
}