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

        
        [AcceptVerbs("GET", "POST")]
        public ActionResult VerifyEmail(string email)
        {
            using(SchoolDbContext db = new SchoolDbContext())
            {
                if(db.Students.Any(x => x.Email == email))
                {
                    return Json($"Email {email} is already in use.");
                }
                else if(db.Teachers.Any(x => x.Email == email))
                {
                    return Json($"Email {email} is already in use.");
                }
            }

            return Json(true);
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
            return View();
        }
    }
}