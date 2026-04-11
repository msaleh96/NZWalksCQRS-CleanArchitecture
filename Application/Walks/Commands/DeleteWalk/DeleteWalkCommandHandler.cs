
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Commands.DeleteWalk;

public sealed class DeleteWalkCommandHandler(IAppDbContext context): IRequestHandler<DeleteWalkCommand>
{

    public async Task Handle(DeleteWalkCommand request, CancellationToken cancellationToken)
    {

        var walk = await context.Walks.FindAsync([request.Id], cancellationToken);
        if (walk is null)
            throw new NotFoundException(nameof(Walk), request.Id);

        context.Walks.Remove(walk);

        await context.SaveChangesAsync(cancellationToken);
    }
}