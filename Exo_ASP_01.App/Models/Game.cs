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
}
