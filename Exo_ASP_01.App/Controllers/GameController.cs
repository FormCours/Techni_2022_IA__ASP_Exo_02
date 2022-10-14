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
            return View();
        }
    }
}
