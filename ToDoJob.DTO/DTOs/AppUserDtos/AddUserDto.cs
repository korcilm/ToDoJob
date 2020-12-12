using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoJob.DTO.DTOs.AppUserDtos
{
    public class AddUserDto
    {
        //[Display(Name = "Ad : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }

        //[Display(Name = "Soyad : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string SurName { get; set; }

        //[Display(Name = "Kullanıcı Adı : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Şifre : ")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Şifrenizi tekrar giriniz : ")]
        //[Compare("Password", ErrorMessage = "Parolanız eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        //[Display(Name = "Email : ")]
        //[EmailAddress(ErrorMessage = "Geçersiz email adresi")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
    }
}
