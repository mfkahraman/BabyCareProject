using FluentValidation;
using BabyCareProject.Entity.Dtos.EventDtos;

public class UpdateEventDtoValidator : AbstractValidator<UpdateEventDto>
{
    public UpdateEventDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Etkinlik kimliği zorunludur.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Etkinlik başlığı boş olamaz.")
            .MaximumLength(100).WithMessage("Etkinlik başlığı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Tarih bilgisi zorunludur.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Başlangıç saati zorunludur.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("Bitiş saati zorunludur.");

        RuleFor(x => x.Location)
            .MaximumLength(150).WithMessage("Konum en fazla 150 karakter olabilir.");
    }
}
