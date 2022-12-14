using System.ComponentModel.DataAnnotations;

namespace Exo_ASP_02.App.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<GameGenre> Genres { get; set; }
        public int ReleaseYear { get; set; }
        public double Price { get; set; }
        public string PEGI { get; set; }
        public string? ImgSrc { get; set; }
    }

    public class GameAdd
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(1900, 3000)]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(0, 1_000_000)]
        public double? Price { get; set; }

        [Required]
        public string PEGI { get; set; }

        [Required]
        [MinLength(1)]
        public List<string> Genres { get; set; }
    }
}
