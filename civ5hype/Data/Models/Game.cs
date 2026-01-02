using System.ComponentModel.DataAnnotations;

namespace civ5hype.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public DateTime PlayedOn { get; set; }

        public string? Comment { get; set; }

        public string? ScreenshotPath { get; set; }

        [Required]
        public string CreatedById { get; set; } = string.Empty;

        public ApplicationUser? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
    }
}

