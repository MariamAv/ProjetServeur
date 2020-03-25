using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class Revue : Model
    {
        public Revue()
        {
            Numero = new HashSet<Numero>();
        }

        //public int Id { get; set; }
        public string Nom { get; set; }
        public string Periodicite { get; set; }

        public virtual ICollection<Numero> Numero { get; set; }
    }
}
