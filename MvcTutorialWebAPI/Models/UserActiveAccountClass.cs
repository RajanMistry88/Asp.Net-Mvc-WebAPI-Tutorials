using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTutorialWebAPI.Models
{
    public class UserActiveAccountClass
    {
        public int UserID { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Action { get; set; }
    }
}