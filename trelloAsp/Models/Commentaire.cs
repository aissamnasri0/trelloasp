using System;
using System.Collections.Generic;

namespace trelloAsp.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public string? Contenu { get; set; }

    public DateTime DateCreation { get; set; }

    public int? IdCarte { get; set; }

    public int? IdUtilisateur { get; set; }

    public virtual Carte? IdCarteNavigation { get; set; } = null!;

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; } = null!;
    
}
