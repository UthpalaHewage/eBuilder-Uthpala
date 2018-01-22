using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_ebuilder.Models
{
    public class employeeLogin
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Email is Required")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name ="Remember me")]
        public bool rememberMe { get; set; }
    }
}