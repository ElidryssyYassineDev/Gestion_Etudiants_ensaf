using Microsoft.EntityFrameworkCore;
using GestionEtudiants.Models;

namespace GestionEtudiants.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            //constructeur vide
        }
        public DbSet<Etudiant> Etudiants {get; set;}
    }
}