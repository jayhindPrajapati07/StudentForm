﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm
{
    internal class DataLogic
    {
        public DataLogic()
        {
            FirstNameValidatorText = "";
            LastNameValidatorText = "";
            GenderValidatorText = "";
            DateOfBirthValidatorText = "";
            AgeValidatorText = "";
        }

        //public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int GenderIndex { get; set; }
        public string Age { get; set; }
        public string Class { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirthDate { get; set; }

        string years = " years";
        
        public static List<string[]> studentList = new List<string[]>();
        public void defaultStudents()
        {
            string[] student1 = {"0", "Jayhind", "Prajapati", "Male", "21 years", "Graduate", "Mumbai", "1/1/2002" };
            string[] student2 = {"1", "Dheeraj", "Gupta", "Male", "21 years", "Graduate", "Mumbai", "1/1/2002" };
            studentList.Add(student1);
            studentList.Add(student2);
        }
        
        public void AddData()
        {
            int StudentId = int.Parse(studentList[studentList.Count - 1][0])+1;
            string[] studentData = {StudentId.ToString(), FirstName, LastName, Gender, Age+years, Class, Address ,DateOfBirth};
            studentList.Add(studentData);
        }
        public void UpdateData(int index)
        {
            string[] studentData = {index.ToString(), FirstName, LastName, Gender, Age+years, Class, Address ,DateOfBirth};
            studentList.RemoveAt(index);
            studentList.Insert(index, studentData);
        }

        public void DeleteData(int index)
        {
            studentList.RemoveAt(index);
        }

        public string FirstNameValidatorText { get; set; }
        public string LastNameValidatorText { get;set; }
        public string GenderValidatorText { get; set; }
        public string DateOfBirthValidatorText { get; set; }
        public string AgeValidatorText { get; set; }
    }
}