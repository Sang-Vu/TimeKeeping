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
        public ActionResult checkSessionAD(string actionName, string controllerName)
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("ADLogin", "Home");

            }
            if (controllerName == "")
            {
                return View(actionName);
            }
            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult Home()
        {
            return checkSessionAD("AdminHome","");
            /*
            if (!checkSessionAD())
            {
                return RedirectToAction("ADLogin", "Home");
            }
            return View("AdminHome");*/
        }

        public ActionResult EmployeeList()
        {
            return checkSessionAD("AdminEmployeeList","");
            //return View();
        }

        public ActionResult TimekeepingInfo()
        {
            //return View();
            return checkSessionAD("AdminTimekeepingInfo","");
        }

        public ActionResult PasswordChange()
        {
            //return View();
            return checkSessionAD("PasswordChange","");
        }

        public ActionResult LogOut()
        {
            Session.Remove("user");
            Session.Remove("userLevel");
            return RedirectToAction("ADLogin", "Home");
        }
    }
}