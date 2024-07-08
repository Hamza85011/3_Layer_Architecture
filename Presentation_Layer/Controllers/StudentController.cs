using BLL.LogicServices;
using BOL.CommonEntites;
using BOL.DatabaseEntites;
using Microsoft.AspNetCore.Mvc;

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
            if(result == "Saved Successfully")
            {
                return RedirectToAction("StudentList");
            }
            return View();
        }
    }
}
