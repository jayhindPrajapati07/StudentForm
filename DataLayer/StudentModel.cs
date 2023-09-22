using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
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



        //for errors
        public string errFirstName { get; set; } = "";
        public string errLastName { get; set; } = "";
        public string errGender { get; set; } = "";
        public string errDateOfBirth { get; set; } = "";
        public string errAge { get; set; } = "";
    }


    
    //public class StudentModel
    //{
    //    public int studentId { get; set; }

    //    [Required(ErrorMessage = "First Name is required.")]
    //    [StringLength(15, MinimumLength = 3, ErrorMessage = "The First Name field should have between 3 and 15 characters.")]
    //    public string FirstName { get; set; }

    //    [Required(ErrorMessage = "Last Name is required.")]
    //    [StringLength(18, MinimumLength = 2, ErrorMessage = "The Last Name field should have between 2 and 18 characters.")]
    //    public string LastName { get; set; }

    //    [Required(ErrorMessage = "Gender is required.")]
    //    public string Gender { get; set; }

    //    [Required(ErrorMessage = "Gender Index is required.")]
    //    public int GenderIndex { get; set; }

    //    [Required(ErrorMessage = "Date of Birth is required.")]
    //    [DataType(DataType.Date)]
    //    public DateTime DateOfBirth { get; set; }

    //    [Required(ErrorMessage = "Age is required.")]
    //    [Range(5, 99, ErrorMessage = "Age value should be between 5 and 99.")]
    //    public int Age { get; set; }

    //    public string Class { get; set; }
    //    public string Address { get; set; }
    //}
}
