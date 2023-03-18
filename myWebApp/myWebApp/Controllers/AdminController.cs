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
            if (Session["user"] == null)
            {
                return RedirectToAction("ADLogin", "Home");

            }
            //return checkSessionAD("AdminHome","");
            //MemberController memberObj = new MemberController();
            //return memberObj.LogOut("ADLogin", "Home");
            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult EmployeeList()
        {
            return checkSessionAD("AdminEmployeeList","");
        }

        public ActionResult TimekeepingInfo()
        {
            return checkSessionAD("AdminTimekeepingInfo","");
        }

        public ActionResult PasswordChange()
        {
            return checkSessionAD("PasswordChange","");
        }

        public ActionResult LogOut()
        {
            MemberController memberObj = new MemberController();
            return memberObj.LogOut("ADLogin","Home");
        }
    }
}