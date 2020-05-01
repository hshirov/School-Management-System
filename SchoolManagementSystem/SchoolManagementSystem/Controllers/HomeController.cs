﻿using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{    
    public class HomeController : Controller
    {
        private StudentBLL studentBLL = new StudentBLL();
        private TeacherBLL teacherBLL = new TeacherBLL();

        public ActionResult Index()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Session["studentID"] != null)
            {
                return View(studentBLL.GetPerson((int)Session["studentID"]));
            }
            else 
            {
                return View(teacherBLL.GetPerson((int)Session["teacherID"]));
            }            
        }
    }
}