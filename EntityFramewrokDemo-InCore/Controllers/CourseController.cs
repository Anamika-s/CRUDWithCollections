using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramewrokDemo_InCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramewrokDemo_InCore.Controllers
{
    public class CourseController : Controller
    {
        static List<Course> courses = null;
        public CourseController()
        {
            if (courses == null)
            {
                courses = new List<Course>()
                {
                     new Course() { Id=1, CourseName="C++", Duration=12, Description="Its a basic course"},

                     new Course() { Id=2, CourseName="C#", Duration=23, Description="Its a semi basic course"},

                     new Course() { Id=3, CourseName="C", Duration=25, Description="Its an advanced course"},

                     new Course() { Id=4, CourseName="DotNet", Duration=45, Description="Its a basic course"},

                     new Course() { Id=5, CourseName="ADO.Net", Duration=5, Description="Its a basic course"},

                     new Course() { Id=6, CourseName="Entity Framework", Duration=5,  Description="Its a basic course"},
                };
            }
        }

        // CRUD Opearations
        // C > Create / Insert
        // R > Read
        // U > Update
        // D > Delete
        public IActionResult Index()
        {
            if (courses != null)
            {
                if (courses.Count > 0)
                {
                    ViewBag.msg = "records";

                }
                return View(courses.ToList());
            }
            else
            {
                ViewBag.msg = "No records";
                return View();
            }
        }

        public IActionResult Display(int id)
        {

            Course course = null;
            course = courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                ViewBag.msg = "found";
                return View(course);
            }
            else
            {
                ViewBag.msg = "Course with this ID is not found";
                return View();
            }
        }

        public IActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }


        /// Traditional Approach
        //[HttpPost]
        //public IActionResult Create(int txtId, string txtName, int txtDuration, string txtDescription)
        //{
        //    Course course = new Course()
        //    {
        //        Id = txtId,
        //        CourseName = txtName,
        //        Description = txtDescription,
        //        Duration = txtDuration
        //    };
        //    courses.Add(course);
        //    return RedirectToAction("Index");
        //}


        // Using FormsCollection Approach
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            Course course = new Course()
            {
                Id = int.Parse(fc["txtId"]),
                CourseName = fc["txtName"].ToString(),
                Description = fc["txtDescription"].ToString(),
                Duration = int.Parse(fc["txtDuration"])
            };
            courses.Add(course);
            return RedirectToAction("Index");
        }


        //// Pass Entire Object
        //[HttpPost]
        //public IActionResult Create(Course course)
        //{
        //    if (course != null)
        //    {
        //        courses.Add(course);
        //    }
        //    return RedirectToAction("Index");
        //}


        public IActionResult Edit(int id)
        {
            bool found = false;
            Course course = null;
          
                course = courses.FirstOrDefault(x => x.Id == id);
                if (course != null)
                {
          
                    ViewBag.msg = "found";
                    return View(course);

                }
            else

            {

                ViewBag.msg = "Record not found";
                return View();
            }
            
        }

        }

    }