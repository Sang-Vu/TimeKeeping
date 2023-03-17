using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myWebApp.Controllers
{
    public class TempController : Controller
    {
        // GET: Temp
        public ActionResult Index()
        {
            return View();
        }
        /*public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
          /*  List<Administrator> adminList = new List<Administrator>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT userName, password FROM administrator";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            adminList.Add(new Administrator
                            {
                                UserName = sdr["userName"].ToString(),
                                Password = sdr["password"].ToString()

                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(adminList);

            //return View();
        }*/
    }
}