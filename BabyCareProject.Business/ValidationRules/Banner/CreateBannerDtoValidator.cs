using BabyCareProject.Entity.Dtos.BannerDtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.ValidationRules.Banner
{
    public class CreateBannerDtoValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerDtoValidator()
        {
            RuleFor(x => x.Slogan)
                .NotEmpty().WithMessage("Slogan alanı boş geçilemez.")
                .MaximumLength(100).WithMessage("Slogan en fazla 100 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Bir görsel dosyası seçilmelidir.")
                .Must(BeAValidImage).WithMessage("Sadece .jpg, .jpeg veya .png uzantılı dosyalar yükleyebilirsiniz.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Banner aktiflik durumu seçilmelidir.");
        }

        private bool BeAValidImage(IFormFile file)
        {
            if (file == null) return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return allowedExtensions.Contains(extension);
        }
    }
}
