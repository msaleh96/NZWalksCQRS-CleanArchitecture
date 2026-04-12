using Application.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Walks.Queries.GetWalkById;

public sealed record GetWalkByIdQuery(Guid Id) : IRequest<Result<WalkDto?>>;