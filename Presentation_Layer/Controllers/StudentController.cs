using BLL.LogicServices;
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
            List<Student> result = new List<Student>();

            result = _studentLogic.GetStudentListLogic().ToList();
                
            return View(result);
        }
    }
}
