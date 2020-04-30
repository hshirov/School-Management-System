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
    }
}