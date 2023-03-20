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
        [Display(Name = "Mã số NV")]
        public string EmployeeID { get; set; }
        [Display(Name = "Ngày")]
        public string Date { get; set; }
        [Display(Name = "Giờ vào")]
        public string TimeIn { get; set; }
        [Display(Name = "Giờ ra")]
        public string TimeOut { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}