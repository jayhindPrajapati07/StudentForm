using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace StudentForm
{
    internal class AddEditBuisnessLogic 
    {


        StudentModel studentModel;
        internal void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }

        private string requiredMessage = "This field is required";

        internal bool ValidateFields()
        {
            bool isValid = true;

            string firstName = studentModel.FirstName;
            string lastName = studentModel.LastName;
            int gender = studentModel.GenderIndex;
            DateTime dateOfBirth = studentModel.DateOfBirth;
            int age = studentModel.Age;

            if (string.IsNullOrEmpty(firstName))
            {
                errFirstName = requiredMessage;
                isValid = false;
            }
            else if (firstName.Length > 15 || firstName.Length < 3)
            {
                errFirstName = "The First Name field should have min 3 characters and max 15 characters";
                isValid = false;
            }
            else
            {
                errFirstName = "";
            }

            if (string.IsNullOrEmpty(lastName))
            {
                errLastName = requiredMessage;
                isValid = false;
            }
            else if (lastName.Length > 18 || lastName.Length < 2)
            {
                errLastName = "The last Name field should have min 2 characters and max 18 characters";
                isValid = false;
            }
            else
            {
                errLastName = "";
            }

            if (gender == -1)
            {
                errGender = requiredMessage;
                isValid = false;
            }
            else
            {
                errGender = "";
            }

            if (dateOfBirth == DateTime.Now.Date)
            {
                errDateOfBirth = requiredMessage;
                isValid = false;
            }
            else
            {
                errDateOfBirth = "";
            }

            if (age==0)
            {
                errAge = requiredMessage;
                isValid = false;
            }
            else if (age > 99 || age < 5)
            {
                errAge = "Age value should be\nbetween 5 and 99";
                isValid = false;
            }
            else
            {
                errAge = "";
            }

            return isValid;
        }

        //Calculate Age from DateOfBirth
        internal void ageCalc(DateTime dob, out int age)
        {
            age = (DateTime.Now.Date.Year - dob.Date.Year);
        }

        //Calculate DateOfBirth from Age
        internal void dobCalc(string Age, out DateTime dob)
        {
            string age = Age;
            if (age == "" || int.Parse(age) > 99)
            {
                dob = DateTime.Now.Date;
            }
            else
            {
                int age1 = int.Parse(age);
                dob = DateTime.Now.Date.AddYears(-age1);
            }
        }

        public string errFirstName { get; set; }
        public string errLastName { get; set; }
        public string errGender { get; set; }
        public string errDateOfBirth{ get; set; }
        public string errAge { get; set; }
    }
}
