using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data;
//using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;

namespace myWebApp.Models
{
    public class Administrator
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }

        private string sqlConnectionString = @"Data Source = localhost;initial catalog=myapp;user id=root;password=";
        public List<Administrator> GetAllAdmin()
        {/*
            string constr, query;
            List<Administrator> adminList = new List<Administrator>();
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            query = "SELECT userName, password FROM administrator";
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
            */
            //--------------------------------
            List<Administrator> adminList = new List<Administrator>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                adminList = connection.Query<Administrator>("SELECT userName, password FROM administrator").ToList() ;
                //adminList = connection.Query<Student>("Select Id, Name, Marks from Student").ToList();
                connection.Close();
            }
            return adminList;
        }
    }
}