using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HW21_MVC.ViewModel
{
    public class UserRegistrationVM
    {
        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [UIHint("password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [UIHint("password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
