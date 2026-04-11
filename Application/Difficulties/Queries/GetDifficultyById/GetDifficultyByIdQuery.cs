using Application.Difficulties.Dtos;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficultyById;

public sealed record GetDifficultyByIdQuery(Guid Id) : IRequest<DifficultyDto?>;