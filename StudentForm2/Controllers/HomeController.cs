using BackEnd;
using Microsoft.AspNetCore.Mvc;
using StudentForm2.Models;
using System.Diagnostics;
using System.Reflection;

namespace StudentForm2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            addDefaultStudent();
        }

        public IActionResult studentdetailform()
        {
            
            return View(DataLayer.studentList);
        }

        [HttpGet("/home/AddEditForm")]
        public IActionResult AddEditForm()
        {
            return View();
        }

        private static bool defaultStudentAdded = false;
        DataLayer dataLayer = new DataLayer();
        void addDefaultStudent()
        {
            if (!defaultStudentAdded)
            {
                dataLayer.defaultStudents();
                defaultStudentAdded = true;
            }
        }

        [HttpPost]
        public IActionResult Save( StudentModel studentModel,bool EditMode,string studentId)
        {
            dataLayer.setStudentModel(studentModel);
            string firstName = studentModel.FirstName;
            string lastName = studentModel.LastName;
            int genderIndex = studentModel.GenderIndex;
            studentModel.Gender = genderIndex == 0 ? "Male" : "Female"; ;
            string dob = studentModel.DateOfBirth.ToString();
            string age = studentModel.Age.ToString();
            string action = HttpContext.Request.Form["action"];
            utilityClass error =new utilityClass();
            error.setStudentModel(studentModel);
            if (action == "Save")
            {
                bool isValid = error.ValidateData(firstName, lastName, genderIndex, dob, age);
                if (isValid)
                {
                    if (!EditMode)
                    {
                        dataLayer.AddData();//Add
                    }
                    else
                    {
                        dataLayer.UpdateData(studentModel.studentId);//Update
                    }
                }
                else
                {
                    ViewData["studentId"] = studentId;
                    return View("AddEditForm",studentModel);
                }
            }
            else if (action == "Delete")
            {
                dataLayer.DeleteData(studentModel.studentId);//Delete
            }
            
            return View("studentdetailform", DataLayer.studentList);
        }

        public IActionResult selectedStudent(string id)
        {
            int index = DataLayer.studentList.FindIndex(student => student[0] == id.ToString());
            string[] Student = DataLayer.studentList[index];
            ViewBag.Student = Student;
            return View("AddEditForm");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}