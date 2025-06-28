using BabyCareProject.Entity.Dtos.OurProgramDtos;
using FluentValidation;

public class CreateOurProgramDtoValidator : AbstractValidator<CreateOurProgramDto>
{
    public CreateOurProgramDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Program başlığı zorunludur.");
        RuleFor(x => x.InstructorId).NotEmpty().WithMessage("Eğitmen seçimi zorunludur.");
        RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");
        RuleFor(x => x.SessionCount).GreaterThan(0);
        RuleFor(x => x.DurationMinute).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    }
}
