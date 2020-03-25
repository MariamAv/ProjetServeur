using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetServeur.Domaine;
using ProjetServeur.Repository;

namespace ProjetServeur.Controllers
{
    [Route("/auteurs")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private AuteurRepo repo;
        public AuteurController(AuteurRepo repo) 
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Auteur> FindAll()
        {
            ICollection<Auteur> auteurs = new List<Auteur>();
            Auteur a1 = new Auteur()
            {
                Id = 0,
                Nom = "Machin",
                Prenom = "Truc",
                Mail = "machin.truc@mail.com"
            };
            Auteur a2 = new Auteur()
            {
                Id = 1,
                Nom = "Toto",
                Prenom = "Titi",
                Mail = "toto.titi@mail.com"
            };
            auteurs.Add(a1);
            auteurs.Add(a2);

            return auteurs;
        }

        [HttpGet]
        [Route("{id}")]
        public Auteur FindById(int id)
        {
            return this.repo.FindById(id);
        }
    }
}