using System.Text.Json;
using Application.Shared.Services.Seed;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Seed;

public class DataExportService : IDataExportService
{
    private readonly ApplicationDbContext _dbContext;

    public DataExportService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExportDataAsync(string path)
    {
        var data = new
        {
            Users = await _dbContext.Users.ToListAsync(),
            Cards = await _dbContext.Cards.ToListAsync(),
            Games = await _dbContext.Games.ToListAsync(),
            UserCards = await _dbContext.UserCards.ToListAsync(),
            GamePlayers = await _dbContext.GamePlayers.ToListAsync()
        };

        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(path, json);
    }
}