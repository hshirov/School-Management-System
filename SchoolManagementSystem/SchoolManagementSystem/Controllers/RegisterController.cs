using Business;
using Data;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private StudentBLL studentBLL = new StudentBLL();
        private TeacherBLL teacherBLL = new TeacherBLL();

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
            using(SchoolDbContext db = new SchoolDbContext())
            {
                if(studentBLL.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else if(teacherBLL.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                studentBLL.AddStudent(student);
                Session["studentID"] = student.Id;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherBLL.AddTeacher(teacher);
                Session["teacherID"] = teacher.Id;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}