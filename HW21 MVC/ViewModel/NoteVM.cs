using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW21_MVC.ViewModel
{
    public class NoteVM
    {        
        [Required(ErrorMessage ="Incorrect Input! Field Surename is not set!")]
        [MaxLength(20)]
        public string Surename { get; set; }

        [Required(ErrorMessage = "Incorrect Input! Field Name is not set!")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Incorrect Input! Field Lastname is not set!")]
        [MaxLength(20)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Incorrect Input! Field Phone is not set!")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Incorrect Input! Field Adress is not set!")]
        [MaxLength(200)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Incorrect Input! Field Description is not set!")]
        [MaxLength(3000)]
        public string Description { get; set; }
    }
}
