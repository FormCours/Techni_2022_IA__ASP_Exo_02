using Exo_ASP_02.App.Data;
using Exo_ASP_02.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo_ASP_02.App.Controllers
{
    public class GameController : Controller
    {
        [ViewData]
        public string Title { get; set; }


        public IActionResult Index()
        {
            // Récuperation des données de la « DB »
            IEnumerable<Game> games = FakeDB.GetGames();

            // Modification du titre de la page
            Title = "Liste";  // Equivalent à → ViewData["Title"] = "...";

            // Génération de la vue avec les données necessaires
            return View(games);
        }

        public IActionResult Detail(int id)
        {
            //Récuperation du jeu
            Game? game = FakeDB.GetGameById(id);

            // Envoi d'une erreur 404 si le jeu n'est pas trouvé
            if(game is null)
            {
                return NotFound();
            }

            // Définition du title de la page
            Title = "Detail de " + game.Name;

            // Génération d'une vue pour un jeu
            return View(game);
        }


        public IActionResult Add()
        {
            Title = "Ajouter un jeu";

            return View();
        }

        [HttpPost]
        public IActionResult Add(GameAdd game)
        {
            if(!ModelState.IsValid)
            {
                Title = "(╯°□°）╯︵ ┻━┻";

                return View();
            }


            List<GameGenre> genres = new List<GameGenre>();
            foreach(string? genre in game.Genres)
            {
                if(genre != null)
                {
                    GameGenre gg = FakeDB.GetOrInsertGenre(genre);

                    genres.Add(gg);
                }
            }

            List<GameGenre> genres2 = game.Genres
                .Where(g => g != null)
                .Select(g => FakeDB.GetOrInsertGenre(g))
                .ToList();


            FakeDB.InsertGame(new Game()
            {
                Name = game.Name,
                Description = game.Description,
                ReleaseYear = game.ReleaseYear,
                Price = (double)game.Price,
                PEGI = game.PEGI,
                Genres = genres
            });

            return RedirectToAction("Index");
        }
    }
}
