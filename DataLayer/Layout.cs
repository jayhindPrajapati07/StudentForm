using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Layout
    {
        //Our Student
        public string OurStudenHeader = "Our Student";
        public string addBtnText = "+Add";
        public string FirstNameColumnHeader = "First Name";
        public string LastNameColumnHeader = "Last Name";
        public string GenderCoumnHeader = "Gender";
        public string AgeColumnHeader = "Age";
        public string ClassColumnHeader = "Class";

        //AddEdit Student
        public string AddStudentHeader = "Add Student";
        public string EditStudentHeader = "Edit Student";
        public string FirstNameLabel = "First Name";
        public string LastNameLabel = "Last Name";
        public string GenderLabel = "Gender";
        public string DateOfBirthLabel = "Date of Birth";
        public string AgeLabel = "Age";
        public string ClassLabel = "Class";
        public string AddressLabel = "Address";
        public string saveBtnText = "Save";
        public string cancelBtnText = "Cancel";
        public string deleteBtnText = "Delete";
        public string stars = "*";

        public int fontSize = 20;
        public string fontFamily = "Times New Roman";

        //errors
        public string requiredMessage = "This field is required";
        public string firstNameSpError= "The First Name field should have min 3 characters and max 15 characters";
        public string lastNameSpError= "The last Name field should have min 2 characters and max 18 characters";
        public string ageSpError= "Age value should be\nbetween 5 and 99";
    }
}
