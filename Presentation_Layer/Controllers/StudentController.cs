using BLL.LogicServices;
using BOL.CommonEntites;
using BOL.DatabaseEntites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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
        public IActionResult Sign_Up()
        
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_Up_Student(UserLogin userLogin)
        {
            string result = _studentLogic.Sign_Up_BLL(userLogin);
            if (result != null)
            {
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return RedirectToAction("Sign_Up", "Student");
            }
        }

        [HttpGet]
        public IActionResult Sign_In()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_In_User(UserLogin userLogin)
        {
            var result = _studentLogic.Sign_In_BLL(userLogin);
            if (result)
            {
                HttpContext.Session.SetString("UserName", userLogin.UserName);
                HttpContext.Session.SetString("Password", userLogin.Password);
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View("Sign_In");
            }
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
