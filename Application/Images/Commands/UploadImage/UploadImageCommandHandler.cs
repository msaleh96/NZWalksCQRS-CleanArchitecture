using Application.Common.Interfaces;
using Application.Images.Dtos;
using Application.Images.Mappers;
using Domain.Image;
using MediatR;

namespace Application.Images.Commands.UploadImage;

public sealed class UploadImageCommandHandler(
    IAppDbContext context,
    IFileStorageService fileStorageService)
    : IRequestHandler<UploadImageCommand, ImageDto>
{
    public async Task<ImageDto> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var extension = Path.GetExtension(request.FileName);

        var fileName = $"{DateTime.UtcNow:yyyyMMdd_HHmmss}{extension}";

        var filePath = await fileStorageService.SaveFileAsync(
            request.FileStream,
            fileName,
            cancellationToken);

        var image = Image.Create(
            fileName,
            request.FileDescription,
            extension,
            request.FileStream.Length,
            filePath);

        context.Images.Add(image);
        await context.SaveChangesAsync(cancellationToken);

        return image.ToDto();
    }
}