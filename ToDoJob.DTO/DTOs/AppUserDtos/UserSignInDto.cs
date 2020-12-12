using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoJob.DTO.DTOs.AppUserDtos
{
    public class UserSignInDto
    {
        //[Display(Name = "Kullanıcı Adı : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Şifre : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }

        //[Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
