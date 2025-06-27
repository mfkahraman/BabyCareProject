using BabyCareProject.Entity.Dtos.OurServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.ValidationRules.Service
{
    public class CreateOurServiceDtoValidator : AbstractValidator<CreateOurServiceDto>
    {
        public CreateOurServiceDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.IconUrl)
                .MaximumLength(300).WithMessage("Icon URL en fazla 300 karakter olabilir.");
        }
    }
}
