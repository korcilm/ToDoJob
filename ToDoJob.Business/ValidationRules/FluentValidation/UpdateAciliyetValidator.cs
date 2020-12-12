using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.AciliyetDtos;

namespace ToDoJob.Business.ValidationRules.FluentValidation
{
    public class UpdateAciliyetValidator:AbstractValidator<UpdateAciliyetDto>
    {
        public UpdateAciliyetValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
