using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class Contient
    {
        public int NumeroId { get; set; }
        public int ArticleId { get; set; }
        public int Id { get; set; }
        public int? PageDebut { get; set; }
        public int? PageFin { get; set; }

        public virtual Article Article { get; set; }
        public virtual Numero Numero { get; set; }
    }
}
