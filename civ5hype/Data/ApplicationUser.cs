using civ5hype.Data.Enums;
using civ5hype.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace civ5hype.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public UserRole Role { get; set; } = UserRole.User;

        public ICollection<Game> CreatedGames { get; set; } = new List<Game>();

        public Player? Player { get; set; }
    }

}
