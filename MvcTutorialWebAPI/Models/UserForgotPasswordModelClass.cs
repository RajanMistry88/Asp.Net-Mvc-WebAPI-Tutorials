using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTutorialWebAPI.Models
{
    public class UserForgotPasswordModelClass
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
    }
}