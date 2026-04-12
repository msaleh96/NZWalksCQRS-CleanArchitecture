using Application.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficultyById;

public sealed record GetDifficultyByIdQuery(Guid Id) : IRequest<Result<DifficultyDto?>>;