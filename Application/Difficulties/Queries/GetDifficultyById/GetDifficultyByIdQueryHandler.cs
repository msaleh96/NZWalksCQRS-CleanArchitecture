using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Difficulties.Mappers;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficultyById;

public sealed class GetDifficultyByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultyByIdQuery, DifficultyDto?>
{
    public async Task<DifficultyDto?> Handle(GetDifficultyByIdQuery request, CancellationToken cancellationToken)
    {
        var difficulty = await context.Difficulties.FindAsync([request.Id], cancellationToken);
        return difficulty?.ToDto();
    }
}
