using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly StudentBll _studentBll = new StudentBll();
        // GET: Classroom
        public ActionResult Index()
        {
            if(Session["studentID"] != null)
            {
                return RedirectToAction("Classmates");
            }
            else if(Session["teacherID"] != null)
            {
                return RedirectToAction("Classes");
            }

            return RedirectToAction("Index", "Login");
        }


        public ActionResult Classmates()
        {
            if(Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudentsFromClass((int)Session["studentID"]));
        }

        public ActionResult Classes()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudents());
        }
    }
}