using civ5hype.Data;
using civ5hype.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace civ5hype.Services
{
    public class GameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games
                .Include(g => g.CreatedBy)
                .Include(g => g.GamePlayers)
                    .ThenInclude(gp => gp.Player)
                .OrderByDescending(g => g.PlayedOn)
                .ToListAsync();
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.CreatedBy)
                .Include(g => g.GamePlayers)
                    .ThenInclude(gp => gp.Player)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            game.CreatedAt = DateTime.UtcNow;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Dictionary<int, int>> GetPlayerWinsAsync()
        {
            return await _context.GamePlayers
                .Where(gp => gp.IsWinner)
                .GroupBy(gp => gp.PlayerId)
                .Select(g => new { PlayerId = g.Key, Wins = g.Count() })
                .ToDictionaryAsync(x => x.PlayerId, x => x.Wins);
        }

        public async Task<Dictionary<int, Dictionary<int, int>>> GetPlayerRankDistributionAsync()
        {
            var rankings = await _context.GamePlayers
                .GroupBy(gp => new { gp.PlayerId, gp.Rank })
                .Select(g => new { g.Key.PlayerId, g.Key.Rank, Count = g.Count() })
                .ToListAsync();

            return rankings
                .GroupBy(r => r.PlayerId)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToDictionary(x => x.Rank, x => x.Count)
                );
        }
    }
}

