﻿using System;
using System.Collections.Generic;

namespace StudentForm
{
    internal class DataLayer
    {

        StudentModel studentModel;
        internal void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }

        private string years = " years";

        public static List<string[]> studentList = new List<string[]>();
        internal void defaultStudents()
        {
            string[] student1 = { "0", "Jayhind", "Prajapati", "Male", "20 years", "Graduate", "Mumbai", "2/20/2003", "0" };
            string[] student2 = { "1", "Dheeraj", "Gupta", "Male", "20 years", "Graduate", "Mumbai", "2/19/2003", "0" };
            studentList.Add(student1);
            studentList.Add(student2);
        }

        internal void AddData()
        {
            int StudentId = studentList.Count != 0 ? int.Parse(studentList[studentList.Count - 1][0]) + 1 : 0;
            string[] studentData = { StudentId.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age + years, studentModel.Class, studentModel.Address, studentModel.DateOfBirth.ToString(), studentModel.GenderIndex.ToString() };
            studentList.Add(studentData);
        }
        internal void UpdateData(int id)
        {
            string[] studentData = { id.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age + years, studentModel.Class, studentModel.Address, studentModel.DateOfBirth.ToString(), studentModel.GenderIndex.ToString() };
            studentList.RemoveAt(id);
            studentList.Insert(id, studentData);
        }

        internal void DeleteData(int id)
        {
            studentList.RemoveAt(id);
        }

    }
}
