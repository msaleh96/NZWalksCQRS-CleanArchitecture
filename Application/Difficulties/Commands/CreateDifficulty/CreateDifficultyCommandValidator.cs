using FluentValidation;

namespace Application.Difficulties.Commands.CreateDifficulty;

public class CreateDifficultyCommandValidator : AbstractValidator<CreateDifficultyCommand>
{
    public CreateDifficultyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
}