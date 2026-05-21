using Application.Common.Interfaces;
using Application.Infrastructure.Identity;
using Domain.Difficulties;
using Domain.Identity;
using Domain.Image;
using Domain.Regions;
using Domain.Walks;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options), IAppDbContext
{
    public DbSet<Walk> Walks => Set<Walk>();
    public DbSet<Difficulty> Difficulties => Set<Difficulty>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<Image> Images => Set<Image>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImageConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalkConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DifficultyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegionConfiguration).Assembly);
    }
}