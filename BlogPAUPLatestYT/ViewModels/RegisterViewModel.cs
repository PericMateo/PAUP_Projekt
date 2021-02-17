using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
