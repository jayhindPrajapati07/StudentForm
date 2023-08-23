using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm
{
    internal class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int GenderIndex { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirthDate { get; set; }
    }
}
