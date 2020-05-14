﻿using Business;
using Data;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly StudentBll _studentBll;
        private readonly TeacherBll _teacherBll;

        public RegisterController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

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
            if (ModelState.IsValid)
            {
                _studentBll.AddStudent(student);
                Session["studentID"] = student.Id;               
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherBll.AddTeacher(teacher);
                Session["teacherID"] = teacher.Id;              
            }
            return RedirectToAction("Index", "Home");
        }
    }
}