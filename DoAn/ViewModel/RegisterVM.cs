using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Không được để trống tên tài khoản.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Không được để trống mật khẩu.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Không được để trống.")]
        [Compare("Password", ErrorMessage = "Mật khẩu và Mật khẩu nhập lại không khớp. ")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Không được để trống Email. ")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. ")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}