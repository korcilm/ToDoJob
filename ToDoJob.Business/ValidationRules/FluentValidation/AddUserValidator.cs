using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.AppUserDtos;

namespace ToDoJob.Business.ValidationRules.FluentValidation
{
    public class AddUserValidator : AbstractValidator<AddUserDto>
    {
        public AddUserValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");

            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez");

            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Parola onay alanı boş geçilemez");

            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolalarınız eşleşmiyor");

            RuleFor(I => I.Email).NotNull().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Geçersiz email adresi");

            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş geçilemez");

            RuleFor(I => I.SurName).NotNull().WithMessage("Soyad alanı boş geçilemez");
        }
    }
}
