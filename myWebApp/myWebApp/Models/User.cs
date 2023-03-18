using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myWebApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AccountPassword { get; set; }
        public string AccountLevel { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
    }
}