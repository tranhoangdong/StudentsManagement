﻿using StudentsManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsManagement.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
       


        public ActionResult DangNhap()
        {
            return View();
        }
        public int SaveData1( string uname, string pwd)
        {
            StudentList stuList = new StudentList();
            stuList.AddData1( uname, pwd);
            int c = 0;
            return 0;
        }
        [HttpPost]
        public int SaveData(string name, string date, string address, string sex, string number,string uname,string pwd)
        {
            StudentList stuList = new StudentList();
            stuList.AddData(name,date,address,sex,number,uname,pwd);
            int c = 0;
            return 0;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKi()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}