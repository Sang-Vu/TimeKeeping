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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Home");
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Home", "Member");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string id, string password)
        {
            //List<User> user = new List<User>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT id, name, accountLevel FROM employee WHERE id='" + id + "' AND accountPassword='" + password + "'";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            Session["user"] = sdr["id"];
                            Session["userName"] = sdr["name"];
                            Session["userLevel"] = sdr["accountLevel"];   
                        }
                    }
                    con.Close();
                }
            }
            if(Session["user"] == null)
            {
                ViewBag.MessageForLogin = "Thông tin đăng nhập không đúng";
                return View("Login");
            }
            return RedirectToAction("Home", "Member");
        }

        public ActionResult ADLogin()
        {
            if(Session["user"] != null)
            {
                return RedirectToAction("Home", "Member");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ADLogin(string id, string password)
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT userName FROM administrator WHERE userName='" + id + "' AND password='" + password + "'";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            Session["user"] = sdr["userName"];
                            Session["userLevel"] = "0";
                        }
                    }
                    con.Close();
                }
            }
            if (Session["user"] == null)
            {
                ViewBag.MessageForLogin = "Thông tin đăng nhập không đúng";
                return View("ADLogin");
            }
            return RedirectToAction("Home", "Member");
        }

        public ActionResult ProgramInfo()
        {
            return View("Info");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}