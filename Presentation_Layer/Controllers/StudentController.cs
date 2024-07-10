using BLL.LogicServices;
using BOL.CommonEntites;
using BOL.DatabaseEntites;
using Microsoft.AspNetCore.Mvc;

//Sign_Up
//Sign_In

namespace Presentation_Layer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentLogic _studentLogic;
        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }
        [HttpGet]
        public IActionResult StudentList()
        {
            StudentModule Model = new StudentModule();

            Model.StudentList = _studentLogic.GetStudentListLogic().ToList();
                
            return View(Model);
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudentPost(Student FormData)
         {
            string result  = _studentLogic.SaveStudentRecordList(FormData);
            if (result != null)
            {
                return RedirectToAction("StudentList" , "Student");
            }
            else {
                return RedirectToAction("CreateStudent", "Student");
            }
        }
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _studentLogic.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudentPost(Student FormData)
        {
            string result = _studentLogic.EditStudentRecordList(FormData);
            if (result != null)
            {
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return RedirectToAction("EditStudent", "Student");
            }
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentLogic.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudentConfirmed(Student student)
        {
            bool isDeleted = _studentLogic.DeleteStudentById(student.StudentId);
            if (isDeleted)
            {
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult StudentDetails(int id)
        {
            var student = _studentLogic.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
