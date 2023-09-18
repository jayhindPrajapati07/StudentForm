using Microsoft.AspNetCore.Mvc;
using StudentForm1.Models;
using System.Diagnostics;
using BackEnd;

namespace StudentForm1.Controllers
{
    public class HomeController : Controller
    { 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult StudentDetailForm()
        {
            return View();
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

        [HttpGet]
        public IActionResult GetStudents()
        {
            addDefaultStudent();
            return Ok(DataLayer.studentList.ToArray());
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentModel studentModel)
        {
            addDefaultStudent();
            dataLayer.setStudentModel(studentModel);
            dataLayer.AddData();
            return Ok("Data received and processed successfully");
        }

        [HttpPost]
        public IActionResult Edit([FromBody] StudentModel studentModel)
        {
            dataLayer.setStudentModel(studentModel);
            dataLayer.UpdateData(studentModel.studentId);
            return Ok("Data received and processed successfully");
        }

        
        [HttpPost]
        public IActionResult Delete([FromBody] int studentId)
        {
            dataLayer.DeleteData(studentId);
            return Ok("Data received and processed successfully");
        }

        public JsonResult selectedStudent(string id)
        {
            int index = DataLayer.studentList.FindIndex(student => student[0] == id.ToString());
            string[] Student = DataLayer.studentList[index];
            return Json(Student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}