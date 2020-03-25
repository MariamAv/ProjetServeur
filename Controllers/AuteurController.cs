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
            return this.repo.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Auteur FindById(int id)
        {
            return this.repo.FindById(id);
        }

        [HttpPost]
        [Route("")]
        public Auteur Save([FromBody]Auteur a)
        {
            return this.repo.Save(a);
        }

        [HttpPut]
        [Route("")]
        public Auteur Update([FromBody]Auteur a)
        {
            return this.repo.Update(a);
        }


    }
}