using System;
using System.Collections.Generic;

namespace trelloAsp.Models;

public partial class Projet
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? DescriptionPro { get; set; }

    public DateTime DateCreation { get; set; }

    public int? IdUtilisateur { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; } = null!;

    public virtual ICollection<Liste>? Listes { get; } = new List<Liste>();

    public virtual ICollection<UtilisateurProjet>? UtilisateurProjets { get; } = new List<UtilisateurProjet>();
    
    
}
