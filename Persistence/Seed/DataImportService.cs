using System.Text.Json;
using Application.Shared.Services.Seed;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Seed;

public class DataImportService : IDataImportService
{
    private readonly ApplicationDbContext _dbContext;

    public DataImportService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ImportDataAsync(string path)
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.Database.MigrateAsync();

        var json = await File.ReadAllTextAsync(path);
        var data = JsonSerializer.Deserialize<SeedData>(json);
        
        _dbContext.AddRange(data.Users);
        _dbContext.AddRange(data.Cards);
        _dbContext.AddRange(data.Games);
        _dbContext.AddRange(data.UserCards);
        _dbContext.AddRange(data.GamePlayers);

        await _dbContext.SaveChangesAsync();
    }

    private class SeedData
    {
        public List<User> Users { get; set; }
        public List<Card> Cards { get; set; }
        public List<Game> Games { get; set; }
        public List<UserCard> UserCards { get; set; }
        public List<GamePlayer> GamePlayers { get; set; }
    }
}