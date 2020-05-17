using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly TeacherBll _teacherBll;
        private readonly StudentBll _studentBll;

        public AdminPanelController()
        {
            _teacherBll = new TeacherBll();
            _studentBll = new StudentBll();
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            return RedirectToAction("Teachers");
        }

        public ActionResult Teachers()
        {
            if(Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_teacherBll.GetAll());
        }

        public ActionResult Students()
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_studentBll.GetAll());
        }

        public ActionResult DeleteTeacher(int id)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            _teacherBll.DeleteTeacher(id);
            return RedirectToAction("Teachers");
        }

        public ActionResult DeleteStudent(int id)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            _studentBll.DeleteStudent(id);
            return RedirectToAction("Students");
        }
    }
}