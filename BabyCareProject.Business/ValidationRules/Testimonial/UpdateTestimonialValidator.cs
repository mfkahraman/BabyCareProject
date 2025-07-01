using BabyCareProject.Entity.Dtos.TestimonialDtos;
using FluentValidation;

namespace BabyCareProject.Business.ValidationRules.TestimonialValidators
{
    public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID alanı boş bırakılamaz.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Ünvan alanı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Ünvan en fazla 50 karakter olabilir.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 arasında olmalıdır.");

            // ImageFile zorunlu değil, güncellenmeyebilir
        }
    }
}
