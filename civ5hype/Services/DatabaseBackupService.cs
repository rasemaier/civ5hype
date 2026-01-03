using civ5hype.Data;
using civ5hype.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace civ5hype.Services
{
    public class DatabaseBackupService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<DatabaseBackupService> _logger;

        public DatabaseBackupService(ApplicationDbContext dbContext, IMemoryCache memoryCache, ILogger<DatabaseBackupService> logger)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<string> ExportDatabaseAsync()
        {
            try
            {
                var export = new DatabaseExport
                {
                    ExportDate = DateTime.UtcNow,
                    Players = await _dbContext.Players.ToListAsync(),
                    Games = await _dbContext.Games
                        .Select(g => new Game
                        {
                            Id = g.Id,
                            PlayedOn = g.PlayedOn,
                            Comment = g.Comment,
                            ScreenshotPath = g.ScreenshotPath,
                            // Exclude ScreenshotData to save memory
                            CreatedById = g.CreatedById,
                            CreatedAt = g.CreatedAt,
                            WinRound = g.WinRound
                        })
                        .ToListAsync(),
                    GamePlayers = await _dbContext.GamePlayers.ToListAsync()
                };

                using var stream = new MemoryStream();
                await JsonSerializer.SerializeAsync(stream, export, new JsonSerializerOptions { WriteIndented = false });
                var bytes = stream.ToArray();

                var cacheKey = Guid.NewGuid().ToString();
                _memoryCache.Set($"backup_{cacheKey}", bytes, TimeSpan.FromMinutes(5));

                _logger.LogInformation("Database exported successfully. Size: {Size} bytes", bytes.Length);
                return cacheKey;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error exporting database");
                throw;
            }
        }

        public async Task ImportDatabaseAsync(string jsonContent)
        {
            try
            {
                var import = JsonSerializer.Deserialize<DatabaseExport>(jsonContent);
                if (import == null)
                {
                    throw new InvalidOperationException("Failed to deserialize import data");
                }

                _logger.LogInformation("Starting import: {PlayerCount} players, {GameCount} games, {GamePlayerCount} game-players",
                    import.Players?.Count ?? 0,
                    import.Games?.Count ?? 0,
                    import.GamePlayers?.Count ?? 0);

                using var transaction = await _dbContext.Database.BeginTransactionAsync();

                try
                {
                    // Clear existing data
                    _logger.LogInformation("Clearing existing data...");
                    _dbContext.GamePlayers.RemoveRange(_dbContext.GamePlayers);
                    _dbContext.Games.RemoveRange(_dbContext.Games);
                    _dbContext.Players.RemoveRange(_dbContext.Players);
                    await _dbContext.SaveChangesAsync();

                    // Import Players
                    if (import.Players != null && import.Players.Any())
                    {
                        _logger.LogInformation("Importing {Count} players...", import.Players.Count);
                        _dbContext.Players.AddRange(import.Players);
                        await _dbContext.SaveChangesAsync();
                    }

                    // Import Games
                    if (import.Games != null && import.Games.Any())
                    {
                        _logger.LogInformation("Importing {Count} games...", import.Games.Count);
                        _dbContext.Games.AddRange(import.Games);
                        await _dbContext.SaveChangesAsync();
                    }

                    // Import GamePlayers
                    if (import.GamePlayers != null && import.GamePlayers.Any())
                    {
                        _logger.LogInformation("Importing {Count} game-players...", import.GamePlayers.Count);
                        _dbContext.GamePlayers.AddRange(import.GamePlayers);
                        await _dbContext.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    _logger.LogInformation("Import completed successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during import, rolling back transaction");
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error importing database");
                throw;
            }
        }

        public async Task<DatabaseStats> GetStatsAsync()
        {
            return new DatabaseStats
            {
                PlayerCount = await _dbContext.Players.CountAsync(),
                GameCount = await _dbContext.Games.CountAsync(),
                GamePlayerCount = await _dbContext.GamePlayers.CountAsync()
            };
        }
    }

    public class DatabaseExport
    {
        public DateTime ExportDate { get; set; }
        public List<Player> Players { get; set; } = new();
        public List<Game> Games { get; set; } = new();
        public List<GamePlayer> GamePlayers { get; set; } = new();
    }

    public class DatabaseStats
    {
        public int PlayerCount { get; set; }
        public int GameCount { get; set; }
        public int GamePlayerCount { get; set; }
    }
}

