using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Difficulties.Mappers;
using Domain.Common.Results;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Queries.GetDifficultyById;

public sealed class GetDifficultyByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultyByIdQuery, Result<DifficultyDto?>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<DifficultyDto?>> Handle(GetDifficultyByIdQuery request, CancellationToken cancellationToken)
    {
        var difficulty = await _context.Difficulties.FindAsync([request.Id], cancellationToken);

        if (difficulty is null)
            return DifficultyErrors.DifficultyNotFound;

        return difficulty?.ToDto();
    }
}
