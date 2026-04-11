using MediatR;

namespace Application.Walks.Commands.DeleteWalk;

public sealed record DeleteWalkCommand(Guid Id) : IRequest;