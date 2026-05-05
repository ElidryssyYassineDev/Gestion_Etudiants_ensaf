using GestionEtudiants.Data;
using GestionEtudiants.Models;
using Microsoft.AspNetCore.Mvc;


namespace GestionEtudiants.Controllers
{
    public class EtudiantController : Controller
    {
        // Liste statique d'étudiants pour l'exemple

        /**private static List<Etudiant> listeEtudiants = new List<Etudiant>
        *{
        *    new Etudiant { Id = 1, Nom = "Doe", Prenom = "John", Age = 20, Filiere = "Informatique" },
        *    new Etudiant { Id = 2, Nom = "Smith", Prenom = "Jane", Age = 22, Filiere = "Mathématiques" },
        *    new Etudiant { Id = 3, Nom = "Brown", Prenom = "Charlie", Age = 21, Filiere = "Physique" }
        *};
        */
        private readonly ApplicationDbContext _context;

        public EtudiantController (ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            // Passer la liste des étudiants à la vue
            var etudiants = _context.Etudiants.ToList();
            return View(etudiants);
        }
        // Action pour afficher le formulaire de création d'un nouvel étudiant
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Etudiant etudiant)
        {
            //etudiant.Id = listeEtudiants.Count + 1; // Générer un ID simple
            _context.Etudiants.Add(etudiant); // Ajouter le nouvel étudiant à la liste
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //action pour supprimer un étudiant
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        //action pour modifier un étudiant
        public IActionResult Edit(int id)
        {
            var etudiant = _context.Etudiants.Find(id);

            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }


        [HttpPost]
        public IActionResult Edit(Etudiant etudiant)
        {
            Etudiant etudiantExistant = _context.Etudiants.Find(etudiant.Id);
            if(etudiantExistant != null)
            {
                etudiantExistant.Nom =etudiant.Nom;
                etudiantExistant.Prenom =etudiant.Prenom;
                etudiantExistant.Age =etudiant.Age;
                etudiantExistant.Filiere =etudiant.Filiere;
                _context.SaveChanges();
                
                
            }
            return RedirectToAction("Index");
        }

    }
}
    