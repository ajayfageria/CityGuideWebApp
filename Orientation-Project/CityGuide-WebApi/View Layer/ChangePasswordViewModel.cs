using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("NewPassword", ErrorMessage = "Password and Confirm Password must match")]
            public string ConfirmPassword { get; set; }

            public string CurrentPassword { get; set; }
    }
}

