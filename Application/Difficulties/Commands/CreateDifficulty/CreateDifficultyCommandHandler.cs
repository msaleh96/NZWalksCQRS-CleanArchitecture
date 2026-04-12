
using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Difficulties.Mappers;
using Domain.Common.Results;
using Domain.Difficulties;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Difficulties.Commands.CreateDifficulty;

public sealed class CreateDifficultyCommandHandler(IAppDbContext context): IRequestHandler<CreateDifficultyCommand, Result<DifficultyDto>>
{

    private readonly IAppDbContext _context = context;

    public async Task<Result<DifficultyDto>> Handle(CreateDifficultyCommand request, CancellationToken cancellationToken)
    {

        var name = request.Name.Trim().ToLower();

        var existingDifficulty = await _context.Difficulties.AnyAsync(d => d.Name!.ToLower() == name, cancellationToken);

        if (existingDifficulty)
            return DifficultyErrors.DifficultyAlreadyExists;


        var difficulty = Difficulty.Create(request.Name.Trim());

        if (difficulty.IsError)
            return difficulty.Errors;

        _context.Difficulties.Add(difficulty.Value);
        await _context.SaveChangesAsync(cancellationToken);

        return difficulty.Value.ToDto();
    }
}