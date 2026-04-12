
using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Difficulties.Mappers;
using Domain.Common.Results;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Commands.DeleteDifficulty;

public sealed class DeleteDifficultyCommandHandler(IAppDbContext context): IRequestHandler<DeleteDifficultyCommand, Result<DifficultyDto>>
{

    private readonly IAppDbContext _context = context;

    public async Task<Result<DifficultyDto>> Handle(DeleteDifficultyCommand request, CancellationToken cancellationToken)
    {

        var difficulty = await _context.Difficulties.FindAsync([request.Id], cancellationToken);
        if (difficulty is null)
            return DifficultyErrors.DifficultyNotFound;

        _context.Difficulties.Remove(difficulty);

        await _context.SaveChangesAsync(cancellationToken);

        return difficulty.ToDto();
    }
}