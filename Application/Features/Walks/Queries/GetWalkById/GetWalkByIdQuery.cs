using Application.Features.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Walks.Queries.GetWalkById;

public sealed record GetWalkByIdQuery(Guid Id) : IRequest<Result<WalkDto?>>;