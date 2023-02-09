﻿using System;
using System.Collections.Generic;

namespace trelloAsp.Models;

public partial class Etiquette
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public int? IdCarte { get; set; }

    public virtual Carte? IdCarteNavigation { get; set; } = null!;
   
}
