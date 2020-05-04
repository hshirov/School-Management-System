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
            return View();
        }

        public ActionResult Classmates()
        {
            return View(_studentBll.GetStudentsFromClass((int)Session["studentID"]));
        }

        public ActionResult Classes()
        {
            return View(_studentBll.GetStudents());
        }
    }
}