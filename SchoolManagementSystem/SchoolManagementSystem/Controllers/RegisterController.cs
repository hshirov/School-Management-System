using Business;
using Data;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly StudentBll _studentBll = new StudentBll();
        private readonly TeacherBll _teacherBll = new TeacherBll();

        // GET: Register
        public ActionResult Index()
        {
            return RedirectToAction("Student");
        }

        public ActionResult Student()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Teacher()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        public JsonResult VerifyEmail(string email)
        {
            using (new SchoolDbContext())
            {
                if(_studentBll.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                if(_teacherBll.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _studentBll.AddStudent(student);
            Session["studentID"] = student.Id;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _teacherBll.AddTeacher(teacher);
            Session["teacherID"] = teacher.Id;
            return RedirectToAction("Index", "Home");
        }
    }
}