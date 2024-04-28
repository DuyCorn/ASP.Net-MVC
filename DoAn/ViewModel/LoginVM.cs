using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Không được để trống tên tài khoản.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
    }
}