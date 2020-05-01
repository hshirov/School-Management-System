using Business;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private StudentBLL StudentBLL = new StudentBLL();
        private TeacherBLL TeacherBLL = new TeacherBLL();

        // GET: Register
        public ActionResult Index()
        {
            return RedirectToAction("Student");
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            return View();
        }

        
        public JsonResult VerifyEmail(string email)
        {
            using(SchoolDbContext db = new SchoolDbContext())
            {
                if(StudentBLL.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else if(TeacherBLL.IsEmailInUse(email))
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
                using (SchoolDbContext db = new SchoolDbContext())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                Session["studentID"] = student.Id;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                using (SchoolDbContext db = new SchoolDbContext())
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                }
                Session["teacherID"] = teacher.Id;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}