using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myWebApp.Models
{
    public class Timekeeping
    {
        public string Id { get; set; }
        public string EmployeeID { get; set; }
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}