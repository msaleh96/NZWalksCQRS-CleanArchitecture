using Application.Difficulties.Dtos;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficulties;

public sealed record GetDifficultiesQuery : IRequest<List<DifficultyDto>>;