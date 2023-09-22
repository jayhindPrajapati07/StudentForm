using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEnd
{
    public class DataLayer
    {

        StudentModel studentModel;
        public void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }

        private string years = " years";

        public static List<string[]> studentList = new List<string[]>();
        public void defaultStudents()
        {
            string[] student1 = { "0", "Jayhind", "Prajapati", "Male", "20 years", "Graduate", "Mumbai", "2/20/2003", "0" };
            string[] student2 = { "1", "Dheeraj", "Gupta", "Male", "20 years", "Graduate", "Mumbai", "2/19/2003", "0" };
            studentList.Add(student1);
            studentList.Add(student2);
        }

        public void AddData()
        {
            int StudentId = studentList.Count != 0 ? int.Parse(studentList[studentList.Count - 1][0]) + 1 : 0;
            string[] studentData = { StudentId.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age + years, studentModel.Class, studentModel.Address, studentModel.DateOfBirth.ToString(), studentModel.GenderIndex.ToString() };
            studentList.Add(studentData);
        }
        public void UpdateData(int id)
        {
            string[] studentData = { id.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age + years, studentModel.Class, studentModel.Address, studentModel.DateOfBirth.ToString(), studentModel.GenderIndex.ToString() };
            //int index = studentList.FindIndex(student => student[0] == id.ToString());
            int index = getStudentById(id);
            if (index != -1)
            {
                studentList[index] = studentData;
            }
        }

        public void DeleteData(int id)
        {
            //int index = studentList.FindIndex(student => student[0] == id.ToString());
            int index = getStudentById(id);
            if (index != -1)
            {
                studentList.RemoveAt(index);
            }
        }

        public int getStudentById(int id)
        {
            int index = studentList.FindIndex(student => student[0] == id.ToString());
            return index;
        }
    }
}
