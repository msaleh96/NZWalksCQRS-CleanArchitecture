using FluentValidation;

namespace Application.Images.Commands.UploadImage;

public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
    public UploadImageCommandValidator()
    {
        RuleFor(x => x.FileStream)
            .NotNull().WithMessage("File is required.")
            .Must(stream => stream.Length > 0)
            .WithMessage("File cannot be empty.");

        RuleFor(x => x.FileName)
            .NotEmpty().WithMessage("File name is required.")
            .Must(HaveValidExtension)
            .WithMessage("Invalid file type. Only jpg, png, jpeg allowed.");

        RuleFor(x => x.FileDescription)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200)
            .WithMessage("Description must not exceed 200 characters.");
    }

    private bool HaveValidExtension(string fileName)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

        var extension = Path.GetExtension(fileName).ToLower();

        return allowedExtensions.Contains(extension);
    }
}