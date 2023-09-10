using Microsoft.AspNetCore.Mvc;
using StudentForm1.Models;
using System.Diagnostics;
using DataAccessLayer;

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

        //public IActionResult AddEditForm()
        //{
        //    return View();
        //}
        [HttpGet("/home/AddEditForm")]
        public IActionResult AddEditForm(string h1Text)
        {
            // Your controller logic here
            return View(); // Return the view or perform other actions as needed
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
            // Your logic here
            addDefaultStudent();
            dataLayer.setStudentModel(studentModel);
            dataLayer.AddData();
            return Ok("Data received and processed successfully");
        }

        [HttpPost]
        public IActionResult Edit([FromBody] StudentModel studentModel)
        {
            // Your logic here
            dataLayer.setStudentModel(studentModel);
            dataLayer.UpdateData(studentModel.studentId);
            return Ok("Data received and processed successfully");
        }

        
        [HttpPost]
        public IActionResult Delete([FromBody] int studentId)
        {
            // Your logic here
            dataLayer.DeleteData(studentId);
            return Ok("Data received and processed successfully");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}