using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm
{
    internal class DataLayer
    {

        StudentModel studentModel;
        public void setStudentModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;
        }
        
        string years = " years";
        
        public static List<string[]> studentList = new List<string[]>();
        public void defaultStudents()
        {
            string[] student1 = {"0", "Jayhind", "Prajapati", "Male", "21 years", "Graduate", "Mumbai", "1/1/2002" ,"0"};
            string[] student2 = {"1", "Dheeraj", "Gupta", "Male", "21 years", "Graduate", "Mumbai", "1/1/2002" ,"0"};
            studentList.Add(student1);
            studentList.Add(student2);
        }
        
        public void AddData()
        {
            int StudentId;
            if (studentList.Count != 0) {StudentId= int.Parse(studentList[studentList.Count - 1][0]) + 1; } else { StudentId= 0;}
            string[] studentData = {StudentId.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age +years, studentModel.Class, studentModel.Address , studentModel.DateOfBirth.ToString() ,studentModel.GenderIndex.ToString()};
            studentList.Add(studentData);
        }
        public void UpdateData(int index)
        {
            string[] studentData = {index.ToString(), studentModel.FirstName, studentModel.LastName, studentModel.Gender, studentModel.Age + years, studentModel.Class, studentModel.Address, studentModel.DateOfBirth.ToString() ,studentModel.GenderIndex.ToString()};
            studentList.RemoveAt(index);
            studentList.Insert(index, studentData);
        }

        public void DeleteData(int index)
        {
            studentList.RemoveAt(index);
        }

    }
}
