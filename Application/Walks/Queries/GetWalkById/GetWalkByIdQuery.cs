using Application.Walks.Dtos;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Queries.GetWalkById;

public sealed record GetWalkByIdQuery(Guid Id) : IRequest<WalkDto?>;