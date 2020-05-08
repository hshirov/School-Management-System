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
        // GET: Profile
        private readonly SchoolDbContext _dbContext;
        public ActionResult Edit()
        {
            // rewrite getting id
            int userId = Convert.ToInt32(_dbContext.Students.FindFirstValue(ClaimTypes.NameIdentifier));

            // Fetch the userprofile
            if (Session["studentID"] != null)
            {
                Student studentIdentity = _dbContext.Students.FirstOrDefault(u => u.Id.Equals(userId));
                Student model = new Student
                {
                    FirstName = studentIdentity.FirstName,
                    LastName = studentIdentity.LastName,
                    Email = studentIdentity.Email,
                    PasswordHash = studentIdentity.PasswordHash,
                    Mobile = studentIdentity.Mobile
                };
                return View("Profile","ProfileStudent");
            }
            else if (Session["teacherID"] != null)
            {
                Teacher teacherIdentity = _dbContext.Teachers.FirstOrDefault(u => u.Id.Equals(userId));
                Teacher model = new Teacher
                {
                    FirstName = teacherIdentity.FirstName,
                    LastName = teacherIdentity.LastName,
                    Email = teacherIdentity.Email,
                    PasswordHash = teacherIdentity.PasswordHash,
                    Mobile = teacherIdentity.Mobile
                };
                return View("Profile", "ProfileTeacher");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}