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
            return View();
        }

        public bool checkSession()
        {
            bool sessionExists = true;
            if (Session["user"] == null)
            {
                sessionExists = false;
            }
            return sessionExists;
        }

        public ActionResult Homepage()
        {
            if (!checkSession())
            {
                return RedirectToAction("Login");
            }
            if (Session["userLevel"].ToString() == "0")
            {
                return RedirectToAction("Home","Admin");
            }
            else if (Session["userLevel"].ToString() == "1")
            {
                return RedirectToAction("Home","Manager");
            }
            else if (Session["userLevel"].ToString() == "2")
            {
                return RedirectToAction("Home","Employee");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Login()
        {
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
                        /*while (sdr.Read())
                        {
                            user.Add(new User
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                AccountPassword = sdr["AccountPassword"].ToString()

                            });
                        }*/
                    }
                    con.Close();
                }
            }
            return Homepage();
        }

        public ActionResult ADLogin()
        {
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
            return Homepage();
        }
    }
}