using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using trelloAsp.Models;

namespace trelloAsp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Carte> Cartes { get; set; }

        public virtual DbSet<Commentaire> Commentaires { get; set; }

        public virtual DbSet<Etiquette> Etiquettes { get; set; }

        public virtual DbSet<Liste> Listes { get; set; }

        public virtual DbSet<Projet> Projets { get; set; }

        

        public virtual DbSet<UtilisateurProjet> UtilisateurProjets { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}