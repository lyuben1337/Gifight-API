using Domain.Shared;

namespace Domain.Entities;

public class Card : BaseEntity
{
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required int Power { get; set; }
    public List<User> Users { get; set; } = [];
    public List<UserCard> UserCards { get; set; } = [];
}