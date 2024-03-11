using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
    public  class ResetPasswordModel
    {
        [Required(ErrorMessage = "Password is required")]
        public string? PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassWord { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
