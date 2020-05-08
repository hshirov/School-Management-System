using Business;
using Data;
using Data.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly StudentBll _studentBll;
        private readonly TeacherBll _teacherBll;

        public ProfileController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        public ActionResult Student()
        {
            return View(_studentBll.GetStudent((int)Session["studentId"]));
        }
        public ActionResult Teacher()
        {
            return View(_studentBll.GetStudent((int)Session["teacherId"]));
        }

        public ActionResult UpdateStudent(Student student)
        {
            student.Id = (int)Session["studentId"];
            _studentBll.UpdateStudent(student);
            return RedirectToAction("Student");
        }

        public ActionResult UpdateTeacher(Teacher teacher)
        {
            return RedirectToAction("Teacher");
        }
    }
}