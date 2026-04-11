using Application.Common.Interfaces;

namespace Infrastructure.Services;

public class LocalFileStorageService : IFileStorageService
{
    public async Task<string> SaveFileAsync(Stream fileStream, string fileName, CancellationToken cancellationToken)
    {
        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        Directory.CreateDirectory(folder);

        var fullPath = Path.Combine(folder, fileName);

        using var stream = new FileStream(fullPath, FileMode.Create);
        await fileStream.CopyToAsync(stream, cancellationToken);

        return $"Images/{fileName}";
    }
}