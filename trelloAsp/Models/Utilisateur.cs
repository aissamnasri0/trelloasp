using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace trelloAsp.Models;

public partial class Utilisateur : IdentityUser
{
   

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }
    public int? idprojet { get; set; }
   

    public DateTime DateInscription { get; set; }

    public virtual ICollection<Commentaire>? Commentaires { get; } = new List<Commentaire>();

    public virtual ICollection<Projet>? Projets { get; } = new List<Projet>();

    public virtual ICollection<UtilisateurProjet>? UtilisateurProjets { get; } = new List<UtilisateurProjet>();
    


}
