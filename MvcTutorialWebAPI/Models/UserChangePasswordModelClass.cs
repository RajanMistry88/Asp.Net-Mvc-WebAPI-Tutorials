using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTutorialWebAPI.Models
{
    public class UserChangePasswordModelClass
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm New Password dose not match")]
        public string ConfirmPassword { get; set; }
    }
}