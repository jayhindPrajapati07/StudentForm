using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentModel
    {
        public int studentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int GenderIndex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
    }
}
