using Application.Images.Dtos;
using MediatR;

namespace Application.Images.Commands.UploadImage;

public sealed record UploadImageCommand( Stream FileStream, string FileName, string FileDescription) : IRequest<ImageDto>;