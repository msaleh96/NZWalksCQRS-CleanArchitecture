using Application.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficulties;

public sealed record GetDifficultiesQuery : IRequest<Result<List<DifficultyDto>>>;