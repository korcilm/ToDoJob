using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.JobDtos;

namespace ToDoJob.Business.ValidationRules.FluentValidation
{
    public class UpdateJobValidator:AbstractValidator<UpdateJobDto>
    {
        public UpdateJobValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı gereklidir");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
