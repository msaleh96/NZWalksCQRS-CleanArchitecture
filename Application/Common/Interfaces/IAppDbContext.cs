using Domain.Difficulties;
using Domain.Identity;
using Domain.Image;
using Domain.Regions;
using Domain.Walks;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Difficulty> Difficulties { get; }

    DbSet<Region> Regions { get; }
    
    DbSet<Walk> Walks { get; }

    DbSet<Image> Images { get; }

    DbSet<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}