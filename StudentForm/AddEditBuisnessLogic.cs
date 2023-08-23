using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm
{
    internal class AddEditBuisnessLogic 
    {


        StudentModel studentModel;
        public void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }

        string requiredMessage = "This field is required";

        public bool ValidateFields()
        {
            bool isValid = true;

            string firstName = studentModel.FirstName;
            string lastName = studentModel.LastName;
            int gender = studentModel.GenderIndex;
            string dateOfBirth= studentModel.DateOfBirth;
            int age = studentModel.Age;

            if (string.IsNullOrEmpty(firstName))
            {
                FirstNameValidatorText = requiredMessage;
                isValid = false;
            }
            else if (firstName.Length > 15 || firstName.Length < 3)
            {
                FirstNameValidatorText = "The First Name field should have min 3 characters and max 15 characters";
                isValid = false;
            }
            else
            {
                FirstNameValidatorText = "";
            }

            if (string.IsNullOrEmpty(lastName))
            {
                LastNameValidatorText = requiredMessage;
                isValid = false;
            }
            else if (lastName.Length > 18 || lastName.Length < 2)
            {
                LastNameValidatorText = "The last Name field should have min 2 characters and max 18 characters";
                isValid = false;
            }
            else
            {
                LastNameValidatorText = "";
            }

            if (gender == -1)
            {
                GenderValidatorText = requiredMessage;
                isValid = false;
            }
            else
            {
                GenderValidatorText = "";
            }

            if (dateOfBirth == DateTime.Now.Date.ToString())
            {
                DateOfBirthValidatorText = requiredMessage;
                isValid = false;
            }
            else
            {
                DateOfBirthValidatorText = "";
            }

            if (age==0)
            {
                AgeValidatorText = requiredMessage;
                isValid = false;
            }
            else if (age > 99 || age < 5)
            {
                AgeValidatorText = "Age value should be\n between 5 and 99";
                isValid = false;
            }
            else
            {
                AgeValidatorText = "";
            }

            return isValid;
        }

        //Calculate Age from DateOfBirth
        public void ageCalc(DateTime dob, out int age)
        {
            DateTime dateofBirth = dob;
            age = (DateTime.Now.Date.Year - dob.Date.Year);
        }

        //Calculate DateOfBirth from Age
        public void dobCalc(string Age, out DateTime dob)
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

        public string FirstNameValidatorText { get; set; }
        public string LastNameValidatorText { get; set; }
        public string GenderValidatorText { get; set; }
        public string DateOfBirthValidatorText { get; set; }
        public string AgeValidatorText { get; set; }
    }
}
