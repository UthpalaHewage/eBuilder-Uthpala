using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_ebuilder.Models
{
    public class leaveApplyForm
    {
        [Required(ErrorMessage ="Date is required")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [DataType(DataType.Text)]
        public string reason { get; set; }

        [Required(ErrorMessage ="Leave Category is required")]
        public string leaveCategory { get; set; }

    }
}