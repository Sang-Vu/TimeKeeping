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
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Homepage()
        {
            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult PasswordChange(string newPassword)
        {
            string query;
            int res;
            if (Session["userLevel"].ToString() == "0")
            {
                query = "UPDATE administrator SET password = '" + newPassword + "' WHERE userName='" + Session["user"].ToString() + "'";
            }
            else
            {
                query = "UPDATE employee SET accountPassword = '" + newPassword + "' WHERE id=" + Session["user"].ToString();
            }
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    res = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return RedirectToAction("Homepage");
        }
    }
}