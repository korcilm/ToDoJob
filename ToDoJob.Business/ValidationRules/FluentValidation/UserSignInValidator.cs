using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.AppUserDtos;

namespace ToDoJob.Business.ValidationRules.FluentValidation
{
    public class UserSignInValidator:AbstractValidator<UserSignInDto>
    {
        public UserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");

            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
