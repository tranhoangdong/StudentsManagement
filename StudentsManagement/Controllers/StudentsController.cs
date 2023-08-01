using StudentsManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsManagement.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
            
        {
            StudentList stuList = new StudentList();
            List<Students> obj = stuList.GetStudents(String.Empty).OrderBy(x => x.ID).ToList();
                return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Create(Students stu)
        {
            if( ModelState.IsValid)
            {
                StudentList stuList = new StudentList();
                    stuList.AddStudent(stu);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit ( string ID = " ")
        {
            StudentList StuList = new StudentList();
            List<Students> obj = StuList.GetStudents(ID);
            return View(obj.FirstOrDefault());
            
        }
        [HttpPost]
        public ActionResult Edit( StudentList stu)
        {
            StudentList StuList = new StudentList();
            StuList.UpdateStudents(stu);
            return RedirectToAction("Index");
        }
    }
}