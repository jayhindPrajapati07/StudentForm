using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm
{
    internal class AddEditBuisnessLogic 
    {
        DataLogic dataLogic;
        public void setDataLogic(DataLogic dataLogic)
        {
            this.dataLogic = dataLogic;
        }

        string requiredMessage = "This field is required";

        public bool ValidateFields()
        {
            bool isValid = true;
            string firstName = dataLogic.FirstName;
            string lastName = dataLogic.LastName;
            int gender = dataLogic.GenderIndex;
            string dateOfBirth=dataLogic.DateOfBirth;
            string age = dataLogic.Age;

            if (string.IsNullOrEmpty(firstName))
            {
                dataLogic.FirstNameValidatorText = requiredMessage;
                isValid = false;
            }
            else if (firstName.Length > 15 || firstName.Length < 3)
            {
                dataLogic.FirstNameValidatorText = "The First Name field should have min 3 characters and max 15 characters";
                isValid = false;
            }
            else
            {
                dataLogic.FirstNameValidatorText = "";
            }

            if (string.IsNullOrEmpty(lastName))
            {
                dataLogic.LastNameValidatorText = requiredMessage;
                isValid = false;
            }
            else if (lastName.Length > 18 || lastName.Length < 2)
            {
                dataLogic.LastNameValidatorText = "The last Name field should have min 2 characters and max 18 characters";
                isValid = false;
            }
            else
            {
                dataLogic.LastNameValidatorText = "";
            }

            if (gender == -1)
            {
                dataLogic.GenderValidatorText = requiredMessage;
                isValid = false;
            }
            else
            {
                dataLogic.GenderValidatorText = "";
            }

            if (dateOfBirth == DateTime.Now.Date.ToString())
            {
                dataLogic.DateOfBirthValidatorText = requiredMessage;
                isValid = false;
            }
            else
            {
                dataLogic.DateOfBirthValidatorText = "";
            }

            if (string.IsNullOrEmpty(age))
            {
                dataLogic.AgeValidatorText = requiredMessage;
                isValid = false;
            }
            else if (int.Parse(age) > 99 || int.Parse(age) < 5)
            {
                dataLogic.AgeValidatorText = "Age value should be\n between 5 and 99";
                isValid = false;
            }
            else
            {
                dataLogic.AgeValidatorText = "";
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
    }
}
