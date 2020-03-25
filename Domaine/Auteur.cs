using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    //extends : Model si utilise classe générique
    public partial class Auteur
    {
        public Auteur()
        {
            Ecrire = new HashSet<Ecrire>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Ecrire> Ecrire { get; set; }
    }
}
