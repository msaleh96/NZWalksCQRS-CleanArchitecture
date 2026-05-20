using Application.Features.Images.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Images.Commands.UploadImage;

public sealed record UploadImageCommand( Stream FileStream, string FileName, string FileDescription) : IRequest<Result<ImageDto>>;