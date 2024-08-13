using Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_2.Controllers
{
    public class AdminController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageCourses()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Cours course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("ManageCourses");
            }

            return View(course);
        }

        public ActionResult ManageStudents()
        {
            var students = db.Students.ToList();
            return View(students);
        }
    }

}