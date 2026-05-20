using Application.Features.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Difficulties.Queries.GetDifficultyById;

public sealed record GetDifficultyByIdQuery(Guid Id) : IRequest<Result<DifficultyDto?>>;