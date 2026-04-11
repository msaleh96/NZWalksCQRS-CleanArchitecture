using FluentValidation;

namespace Application.Regions.Commands.CreateRegion;

public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .MaximumLength(10)
            .WithMessage("Code must not exceed 10 characters.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.imageUrl)
            .MaximumLength(200)
            .WithMessage("Image URL must not exceed 200 characters.");
            
    }
}