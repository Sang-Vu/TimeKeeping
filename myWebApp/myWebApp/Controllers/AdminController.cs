using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using myWebApp.Models;

namespace myWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult EmployeeList()
        {
            return View("AdminHome");
           
        }

        public ActionResult TimekeepingInfo()
        {
            return View("AdminHome");
            
        }

        public ActionResult PasswordChange()
        {
            return View("AdminHome");
            
        }

        public ActionResult LogOut()
        {
            return View();
           // MemberController memberObj = new MemberController();
          //  return memberObj.LogOut("ADLogin","Home");
        }
    }
}