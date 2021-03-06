﻿using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class Numero : Model
    {
        public Numero()
        {
            Contient = new HashSet<Contient>();
            NumeroHasContient = new HashSet<NumeroHasContient>();
        }

        public int Nombre { get; set; }
        public int Annee { get; set; }
        public int? Nbpages { get; set; }
        public int RevueId { get; set; }
        //public int Id { get; set; }

        public virtual Revue Revue { get; set; }
        public virtual ICollection<Contient> Contient { get; set; }
        public virtual ICollection<NumeroHasContient> NumeroHasContient { get; set; }
    }
}
