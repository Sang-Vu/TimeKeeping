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
        public ActionResult Home()
        {
            if (Session["user"] != null)
            {
                if (Session["userLevel"].ToString() == "0")
                {
                    return RedirectToAction("Home", "Admin");
                }
                else if (Session["userLevel"].ToString() == "1")
                {
                    return RedirectToAction("Home", "Manager");
                }
                else
                //Session["userLevel"].ToString() == "2"
                {
                    return RedirectToAction("Home", "Employee");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return Home();
        }

        public ActionResult LogOut()
        {
            Session.Remove("user");
            Session.Remove("userName");
            Session.Remove("userLevel");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EmployeeList()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
                string query, constr;
            List<User> userList = new List<User>();
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if (Session["userLevel"].ToString() == "0" || Session["userLevel"].ToString() == "1")
            {
                if (Session["userLevel"].ToString() == "0")
                {
                    query = "SELECT id, name FROM employee WHERE accountLevel<>'0'";
                }
                else
                {
                    query = "SELECT employee.id, employee.name FROM management INNER JOIN employee ON management.employeeID = employee.id WHERE management.managerID='" + Session["user"] + "'";
                }
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                userList.Add(new User
                                {
                                    Id = sdr["id"].ToString(),
                                    Name = sdr["name"].ToString()
                                });
                            }
                        }
                        con.Close();
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(userList);
        }

        public ActionResult Timekeeping()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult TimekeepingInfo()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string constr, query, timeSearch;
            timeSearch = DateTime.Now.ToString("MM/yyyy");
            if (Session["userLevel"].ToString() == "0")
            {
                return RedirectToAction("TimekeepingListOfMember");
                //query = "SELECT * FROM timekeeping WHERE date LIKE '%/" + timeSearch + "'";
            }
            else
                //Session["userLevel"].ToString() == "1" || Session["userLevel"].ToString() == "2"
            {
                query = "SELECT * FROM timekeeping WHERE employeeID = '" + Session["user"] + "' AND date LIKE '%/" + timeSearch + "'";
            }
    
            List<Timekeeping> timekeepingList = new List<Timekeeping>();
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;          
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            timekeepingList.Add(new Timekeeping
                            {
                                EmployeeID = sdr["employeeID"].ToString(),
                                Date = sdr["date"].ToString(),
                                TimeIn = sdr["timeIn"].ToString(),
                                TimeOut = sdr["timeOut"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            ViewBag.timeKeeping = "personal";
            return View("TimekeepingList", timekeepingList);
        }
        
        public ActionResult TimekeepingListOfMember()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string constr, query, timeSearch, employeeID="";
            timeSearch = DateTime.Now.ToString("MM/yyyy");

            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<User> user_1 = new List<User>();
            MySqlDataReader sdr;
            MySqlCommand cmd;
            string userInfo;
            List<string> user_2 = new List<string>();
            List<Timekeeping> timekeepingList = new List<Timekeeping>();

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                conn.Open();
                query = "SELECT employee.id, employee.name FROM management INNER JOIN employee ON management.employeeID = employee.id WHERE management.managerID='" + Session["user"] + "'";
                using (cmd = new MySqlCommand(query, conn))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        user_1.Add(new User {
                            Id = sdr["id"].ToString(),
                            Name = sdr["name"].ToString()
                        });
                    }  
                }
                conn.Close();
                if(user_1.Count > 0)
                {
                    foreach (User eachUser in user_1)
                    {
                        conn.Open();
                        if (employeeID == "")
                        {
                            employeeID = eachUser.Id;
                        }
                        query = "SELECT employee.id, employee.name FROM management INNER JOIN employee ON management.employeeID = employee.id WHERE management.managerID='" + eachUser.Id + "'";
                        userInfo = eachUser.Id + "-" + eachUser.Name;
                        user_2.Add(userInfo);
                        using (cmd = new MySqlCommand(query, conn))
                        {
                            sdr = cmd.ExecuteReader();
                            while(sdr.Read())
                            {
                                userInfo = sdr["id"].ToString() + "-" + sdr["name"].ToString();
                                user_2.Add(userInfo);
                            }
                        }
                        conn.Close();
                    }  
                }
                Session["employeeList"] = user_2;
                
                if(employeeID != "")
                {
                    conn.Open();
                    query = "SELECT * FROM timekeeping WHERE employeeID='" + employeeID + "' AND date LIKE '%/" + timeSearch + "'";
                    using (cmd = new MySqlCommand(query, conn))
                    {
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            timekeepingList.Add(new Timekeeping
                            {
                                EmployeeID = sdr["employeeID"].ToString(),
                                Date = sdr["date"].ToString(),
                                TimeIn = sdr["timeIn"].ToString(),
                                TimeOut = sdr["timeOut"].ToString()
                            });
                        }   
                    }
                    conn.Close();
                }
            }
            ViewBag.employeeSelected = employeeID;
            ViewBag.timeKeeping = "member";
            return View("TimekeepingList", timekeepingList);
        }

        [HttpPost]
        public ActionResult TimekeepingListOfMember(string employeeID)
        {
            List<Timekeeping> timekeepingList = new List<Timekeeping>();
            string constr, query, timeSearch;
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader sdr;

            timeSearch = DateTime.Now.ToString("MM/yyyy");
            query = "SELECT * FROM timekeeping WHERE employeeID='" + employeeID + "' AND date LIKE '%/" + timeSearch + "'";
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (conn = new MySqlConnection(constr))
            {
                conn.Open();
                cmd = new MySqlCommand(query,conn);
                sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    timekeepingList.Add(new Timekeeping
                    {
                        EmployeeID = sdr["employeeID"].ToString(),
                        Date = sdr["date"].ToString(),
                        TimeIn = sdr["timeIn"].ToString(),
                        TimeOut = sdr["timeOut"].ToString()
                    });
                }
                
                conn.Close();
            }
            ViewBag.employeeSelected = employeeID;
            ViewBag.timeKeeping = "member";
            return View("TimekeepingList", timekeepingList);
        }

        public ActionResult TimekeepingDo()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string query = "";
            string constr;
            int res;
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (Request["TimekeepingIn"] != null)
            {
                query = "INSERT INTO timekeeping (employeeID,date,timeIn) VALUES ("+ Session["user"] +",'"+ date + "','"+ time +"')";
            }
            else if (Request["TimekeepingOut"] != null)
            {
                query = "INSERT INTO timekeeping (employeeID,date,timeOut) VALUES (" + Session["user"] + ",'" + date + "','" + time + "')";
            }
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            return Home();
        }
    }
}