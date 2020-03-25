using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetServeur.Domaine;

namespace ProjetServeur.Controllers
{
    [Route("/auteurs")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        public AuteurController() { }
        public IEnumerable<Auteur> FindAll()
        {
            ICollection<Auteur> auteurs = new List<Auteur>();
            Auteur a1 = new Auteur()
            {
                Nom = "Machin",
                Prenom = "Truc",
                Mail = "machin.truc@mail.com"
            };
            Auteur a2 = new Auteur()
            {
                Nom = "Toto",
                Prenom = "Titi",
                Mail = "toto.titi@mail.com"
            };
            auteurs.Add(a1);
            auteurs.Add(a2);

            return auteurs;
        }
    }
}