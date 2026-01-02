using civ5hype.Data;
using civ5hype.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace civ5hype.Services
{
    public class PlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.User)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.User)
                .Include(p => p.GamePlayers)
                    .ThenInclude(gp => gp.Game)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            player.CreatedAt = DateTime.UtcNow;
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}

