using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterCloneApp.Models
{
    public class UserModel
    {
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        [Display(Name ="User Name")]        
        public string username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="Error message", MinimumLength =4)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50,ErrorMessage ="Enter valid email address")]
        [Display(Name ="Email Address")]
        public string email { get; set; }
        
    }
}