using Application.Common.Interfaces;

namespace Application.Difficulties.Dtos;

public class DifficultyDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}