using System.ComponentModel.DataAnnotations;

namespace civ5hype.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
    }
}

