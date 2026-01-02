using System.ComponentModel.DataAnnotations;

namespace civ5hype.Data.Models
{
    public class GamePlayer
    {
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game? Game { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public Player? Player { get; set; }

        [Required]
        [Range(1, 8)]
        public int Rank { get; set; }

        public bool IsWinner { get; set; }

        [StringLength(50)]
        public string? Civilization { get; set; }
        
        // Fun-Statistiken (zählen nicht zur Hauptstatistik)
        public bool HalberSiegOpStart { get; set; } // Zählt nur als halber Sieg da OP Start
        public bool SiegerDerHerzen { get; set; } // Sieger der Herzen
        public bool Betrueger { get; set; } // Betrüger
    }
}

