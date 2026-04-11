using FluentValidation;

namespace Application.Walks.Commands.UpdateWalk;

public class UpdateWalkCommandValidator : AbstractValidator<UpdateWalkCommand>
{
    public UpdateWalkCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(200)
            .WithMessage("Description must not exceed 200 characters.");

        RuleFor(x => x.LengthInKm)
            .GreaterThan(0)
            .WithMessage("Length in km must be a positive number.");

        RuleFor(x => x.DifficultyId)
            .NotEqual(Guid.Empty)
            .WithMessage("Difficulty ID is required.");

        RuleFor(x => x.RegionId)
            .NotEqual(Guid.Empty)
            .WithMessage("Region ID is required.");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(200)
            .WithMessage("Image URL must not exceed 200 characters.");
            
    }
}