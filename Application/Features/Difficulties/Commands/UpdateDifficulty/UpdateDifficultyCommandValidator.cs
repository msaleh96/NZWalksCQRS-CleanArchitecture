using FluentValidation;

namespace Application.Features.Difficulties.Commands.UpdateDifficulty;

public class UpdateDifficultyCommandValidator : AbstractValidator<UpdateDifficultyCommand>
{
    public UpdateDifficultyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
}