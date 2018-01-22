using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_ebuilder.Models
{
    public class employeeRegister
    {
        [Required (AllowEmptyStrings = false,ErrorMessage = "EID is required") ]
        public string EID { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required (AllowEmptyStrings =false, ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [DataType (DataType.Date)]
        public DateTime dob { get; set; }

        [Required (AllowEmptyStrings =false,ErrorMessage ="First Name is required")]
        [DataType(DataType.Text)]
        public string fName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [DataType(DataType.Text)]
        public string lName { get; set; }

        [Required]
        public string gender { get; set; }

        public string homeNo { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        [Required]
        public string jobCategory { get; set; }

    }
}