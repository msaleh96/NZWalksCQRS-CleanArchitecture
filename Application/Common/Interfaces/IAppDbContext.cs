using Domain.Difficulties;
using Domain.Regions;
using Domain.Todos;
using Domain.Walks;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Todo> Todos { get; }

    DbSet<Difficulty> Difficulties { get; }

    DbSet<Region> Regions { get; }
    
    DbSet<Walk> Walks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}