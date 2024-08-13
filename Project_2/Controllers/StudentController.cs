using Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_2.Controllers
{
    public class StudentController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        public ActionResult Index(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        public ActionResult Courses(int id)
        {
            var courses = db.Courses.ToList();
            ViewBag.StudentId = id;
            return View(courses);
        }

        public ActionResult Enroll(int studentId, int courseId)
        {
            db.StudentCourses.Add(new StudentCours
            {
                StudentId = studentId,
                CourseId = courseId
            });
            db.SaveChanges();
            return RedirectToAction("Courses", new { id = studentId });
        }

        public ActionResult EnrolledCourses(int id)
        {
            var enrolledCourses = db.StudentCourses
                                    .Where(sc => sc.StudentId == id)
                                    .Select(sc => sc.Cours)
                                    .ToList();
            return View(enrolledCourses);
        }
    }

}