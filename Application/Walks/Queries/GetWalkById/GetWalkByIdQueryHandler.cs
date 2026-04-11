using Application.Common.Interfaces;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Queries.GetWalkById;

public sealed class GetWalkByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetWalkByIdQuery, Walk?>
{
    public async Task<Walk?> Handle(GetWalkByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Walks.FindAsync([request.Id], cancellationToken);
    }
}
