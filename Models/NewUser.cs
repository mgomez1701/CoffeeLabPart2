using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopLab.Models
{
    public class NewUser
    {
        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Username requires min 8 characters")]
        public string UserName { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 8, ErrorMessage = "E-Mail requires min 8 characters with valid @.com")]
        public string Email { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 8, ErrorMessage = "Password requires min 8 characters")]
        public string Password { get; set; }

    }
}
