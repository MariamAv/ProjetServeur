using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class Ecrire
    {
        public int ArticleId { get; set; }
        public int AuteurId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Auteur Auteur { get; set; }
    }
}
