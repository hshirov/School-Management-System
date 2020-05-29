﻿using Business;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IStudentBll _studentBll;
        private readonly ITeacherBll _teacherBll;

        public ProfileController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        public ActionResult Student()
        {
            if (Session["studentID"] == null && Session["teacherId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Session["teacherId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_studentBll.GetStudent((int)Session["studentId"]));
        }

        public ActionResult Teacher()
        {
            if (Session["studentID"] == null && Session["teacherId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Session["studentID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_teacherBll.GetTeacher((int)Session["teacherId"]));
        }

        public ActionResult DeactivateStudent()
        {
            return View();
        }

        public ActionResult DeactivateTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            student.Id = (int)Session["studentId"];
            _studentBll.UpdateStudent(student);
            ViewData["Message"] = "Success";
            return View("Student");
        }

        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            teacher.Id = (int)Session["teacherId"];
            _teacherBll.UpdateTeacher(teacher);
            ViewData["Message"] = "Success";
            return View("Teacher");
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            student.Id = (int)Session["studentId"];
            if (!_studentBll.IsPasswordValid(student))
            {
                ViewData["Message"] = "Error";
                return View("DeactivateStudent");
            }
            else
            {
                _studentBll.DeleteStudent(student.Id);
                return RedirectToAction("LogOut", "Login");
            }
        }

        [HttpPost]
        public ActionResult DeleteTeacher(Teacher teacher)
        {
            teacher.Id = (int)Session["teacherId"];
            if (!_teacherBll.IsPasswordValid(teacher))
            {
                ViewData["Message"] = "Error";
                return View("DeactivateTeacher");
            }
            else
            {
                _teacherBll.DeleteTeacher(teacher.Id);
                return RedirectToAction("LogOut", "Login");
            }
        }
    }
}