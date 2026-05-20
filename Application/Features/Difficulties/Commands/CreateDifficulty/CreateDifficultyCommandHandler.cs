
using Application.Common.Interfaces;
using Application.Features.Difficulties.Dtos;
using Application.Features.Difficulties.Mappers;
using Domain.Common.Results;
using Domain.Difficulties;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;

namespace Application.Features.Difficulties.Commands.CreateDifficulty;

public sealed class CreateDifficultyCommandHandler(IAppDbContext context, ILogger<CreateDifficultyCommandHandler> logger, HybridCache cache): IRequestHandler<CreateDifficultyCommand, Result<DifficultyDto>>
{

    private readonly IAppDbContext _context = context;
    private readonly ILogger<CreateDifficultyCommandHandler> _logger = logger;
    private readonly HybridCache _cache = cache;

    public async Task<Result<DifficultyDto>> Handle(CreateDifficultyCommand command, CancellationToken cancellationToken)
    {

        var name = command.Name.Trim().ToLower();

        var existingDifficulty = await _context.Difficulties.AnyAsync(d => d.Name!.ToLower() == name, cancellationToken);

        if (existingDifficulty)
        {
            _logger.LogWarning("Difficulty with name {Name} already exists.", command.Name);
            return DifficultyErrors.DifficultyAlreadyExists;
        }


        var difficulty = Difficulty.Create(command.Name.Trim());

        if (difficulty.IsError)
            return difficulty.Errors;

        _context.Difficulties.Add(difficulty.Value);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Difficulty created with ID: {Id}", difficulty.Value.Id);

        await _cache.RemoveByTagAsync("difficulty", cancellationToken);

        return difficulty.Value.ToDto();
    }
}