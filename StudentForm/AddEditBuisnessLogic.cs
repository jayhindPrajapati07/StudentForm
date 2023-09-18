using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;


namespace StudentForm
{
    internal class AddEditBuisnessLogic 
    {


        StudentModel studentModel;
        Layout layout = new Layout();
        internal void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }
        
        

        internal bool ValidateFields()
        {
            bool isValid = true;
            string requiredMessage = layout.requiredMessage;
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
                errFirstName = layout.firstNameSpError;
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
                errLastName = layout.lastNameSpError;
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
                errAge = layout.ageSpError;
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
