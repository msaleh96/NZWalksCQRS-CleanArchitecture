using Domain.Walks;
using MediatR;

namespace Application.Walks.Queries.GetWalks;

public sealed record GetWalksQuery : IRequest<List<Walk>>;