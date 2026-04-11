using Application.Walks.Dtos;
using MediatR;

namespace Application.Walks.Queries.GetWalks;

public sealed record GetWalksQuery : IRequest<List<WalkDto>>;