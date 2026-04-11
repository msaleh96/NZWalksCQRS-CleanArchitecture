using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficulties;

public sealed record GetDifficultiesQuery : IRequest<List<Difficulty>>;