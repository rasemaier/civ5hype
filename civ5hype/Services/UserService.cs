using civ5hype.Data;
using civ5hype.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace civ5hype.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Player)
                .OrderBy(u => u.UserName)
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> UpdateUserRoleAsync(string userId, UserRole role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.Role = role;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> IsUserInRoleAsync(ApplicationUser user, UserRole role)
        {
            return user.Role >= role;
        }
    }
}

