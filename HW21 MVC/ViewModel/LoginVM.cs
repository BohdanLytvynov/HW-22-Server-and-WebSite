using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HW21_MVC.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="User name was not set!")]
        [Display(Name ="Login")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password was not set!")]
        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password field was not set!")]
        [Display(Name ="Remember me.")]
        public bool RememberMe { get; set; }
    }
}
