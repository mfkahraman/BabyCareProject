using FluentValidation;
using BabyCareProject.Entity.Dtos.OurProgramDtos;

public class UpdateOurProgramDtoValidator : AbstractValidator<UpdateOurProgramDto>
{
    public UpdateOurProgramDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Program başlığı boş olamaz.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ücret sıfırdan büyük olmalıdır.");
        RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Kapasite sıfırdan büyük olmalıdır.");
        RuleFor(x => x.SessionCount).GreaterThan(0).WithMessage("Seans sayısı sıfırdan büyük olmalıdır.");
        RuleFor(x => x.DurationMinute).GreaterThan(0).WithMessage("Süre sıfırdan büyük olmalıdır.");
        RuleFor(x => x.InstructorId).NotEmpty().WithMessage("Eğitmen seçilmelidir.");
    }
}
