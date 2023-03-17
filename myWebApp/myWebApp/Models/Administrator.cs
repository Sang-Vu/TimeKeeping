using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebApp.Models
{
    public class Administrator
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
    }
}