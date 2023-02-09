using System;
using System.Collections.Generic;

namespace trelloAsp.Models;

public partial class UtilisateurProjet
{
    public int Id { get; set; }

    public int IdUtilisateur { get; set; }

    public int IdProjet { get; set; }

    public virtual Projet? IdProjetNavigation { get; set; } = null!;

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; } = null!;
    
}
