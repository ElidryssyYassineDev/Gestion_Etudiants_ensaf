using GestionEtudiants.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
    public class EtudiantController : Controller
    {
        public IActionResult Index()
        {
            var listeEtudiants = new List<Etudiant>
            {
                new Etudiant { Id = 1, Nom = "Doe", Prenom = "John", Age = 20, Filiere = "Informatique" },
                new Etudiant { Id = 2, Nom = "Smith", Prenom = "Jane", Age = 22, Filiere = "Mathématiques" },
                new Etudiant { Id = 3, Nom = "Brown", Prenom = "Charlie", Age = 21, Filiere = "Physique" }
            };

            return View(listeEtudiants);
        }
    }
}
    