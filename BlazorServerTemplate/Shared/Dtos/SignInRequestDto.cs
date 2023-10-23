using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.Dtos
{
    public class SignInRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "وارد کردن نام کاربری الزامیست")]        
        [Display( Name = "نام کاربری")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false,  ErrorMessageResourceName = "وارد کردن رمز عبور الزامیست")]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }
    }
}
