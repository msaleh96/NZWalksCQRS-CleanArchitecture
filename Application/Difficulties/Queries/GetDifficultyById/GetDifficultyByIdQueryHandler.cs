using Application.Common.Interfaces;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficultyById;

public sealed class GetDifficultyByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultyByIdQuery, Difficulty?>
{
    public async Task<Difficulty?> Handle(GetDifficultyByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Difficulties.FindAsync([request.Id], cancellationToken);
    }
}
