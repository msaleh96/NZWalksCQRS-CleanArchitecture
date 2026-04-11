using Application.Common.Interfaces;
using Domain.Difficulties;
using Domain.Regions;
using Domain.Todos;
using Domain.Walks;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
: DbContext(options), IAppDbContext
{
    public DbSet<Todo> Todos => Set<Todo>();
    public DbSet<Walk> Walks => Set<Walk>();
    public DbSet<Difficulty> Difficulties => Set<Difficulty>();
    public DbSet<Region> Regions => Set<Region>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalkConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DifficultyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegionConfiguration).Assembly);
    }
}