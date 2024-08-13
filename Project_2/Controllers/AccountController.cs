using Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_2.Controllers
{
    public class AccountController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Email == "admin@gmail.com" && user.Password == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            var student = db.Students.FirstOrDefault(s => s.Email == user.Email && s.Password == user.Password);
            if (student != null)
            {
                return RedirectToAction("Index", "Student", new { id = student.StudentId });
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(student);
        }
    }

}