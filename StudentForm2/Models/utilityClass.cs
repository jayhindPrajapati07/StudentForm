using DataAccessLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentForm2.Models
{
    public class utilityClass
    {
        StudentModel studentModel;
        public void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }
        Layout layout = new Layout();
        public bool ValidateData(string firstName, string lastName, int genderIndex, string dob, string age)
        {
            bool isValid = true;
            string requiredMessage = layout.requiredMessage;
            if (string.IsNullOrEmpty(firstName))
            {
                studentModel.errFirstName = requiredMessage;
                isValid = false;
            }
            else if (firstName.Length > 15 || firstName.Length < 3)
            {
                studentModel.errFirstName = layout.firstNameSpError;
                isValid = false;
            }
            else
            {
                studentModel.errFirstName = "";
            }

            if (string.IsNullOrEmpty(lastName))
            {
                studentModel.errLastName = requiredMessage;
                isValid = false;
            }
            else if (lastName.Length > 18 || lastName.Length < 2)
            {
                studentModel.errLastName = layout.lastNameSpError;
                isValid = false;
            }
            else
            {
                studentModel.errLastName = "";
            }

            if (genderIndex == -1)
            {
                studentModel.errGender = requiredMessage;
                isValid = false;
            }
            else
            {
                studentModel.errGender = "";
            }

            //if (dob == DateTime.Now.Date.ToString())
            //{
            //    studentModel.errDateOfBirth = requiredMessage;
            //    isValid = false;
            //}
            //else
            //{
            //    studentModel.errDateOfBirth = "";
            //}

            if (int.Parse(age) == 0)
            {
                studentModel.errAge = requiredMessage;
                isValid = false;
            }
            else if (int.Parse(age) > 99 || int.Parse(age) < 5)
            {
                studentModel.errAge = layout.ageSpError ;
                isValid = false;
            }
            else
            {
                studentModel.errAge = "";
            }
            return isValid;
        }


    }


}
