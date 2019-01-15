using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTutorialWebAPI.Models
{
    public class UserLoginModelClass
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Remote("CheckMobileNo", "User", ErrorMessage = "Mobile No Already Added.")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
