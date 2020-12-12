using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.RaporDtos;

namespace ToDoJob.Business.ValidationRules.FluentValidation
{
    public class AddRaporValidator:AbstractValidator<AddRaporDto>
    {
        public AddRaporValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım alanı gereklidir");
            RuleFor(I => I.Detail).NotNull().WithMessage("Detay alanı gereklidir");
        }
    }
}
