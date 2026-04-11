using Domain.Common;

namespace Domain.Image;

public class Image : AuditableEntity
{
    public string FileName { get; private set; } = default!;
    public string FileDescription { get; private set; } = default!;
    public string FileExtension { get; private set; } = default!;
    public long FileSizeInBytes { get; private set; }
    public string FilePath { get; private set; } = default!;

    private Image() { }

    private Image(
        string fileName,
        string fileDescription,
        string fileExtension,
        long fileSizeInBytes,
        string filePath)
    {
        FileName = fileName;
        FileDescription = fileDescription;
        FileExtension = fileExtension;
        FileSizeInBytes = fileSizeInBytes;
        FilePath = filePath;
    }

    public static Image Create(
        string fileName,
        string fileDescription,
        string fileExtension,
        long fileSizeInBytes,
        string filePath)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File name is required");

        return new Image(fileName, fileDescription, fileExtension, fileSizeInBytes, filePath);
    }
}