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
    [Route("/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private ArticleRepo repo;
        public ArticleController(ArticleRepo repo) 
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Article> FindAll()
        {
            return this.repo.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Article FindById(int id)
        {
            return this.repo.FindById(id);
        }

        [HttpPost]
        [Route("")]
        public Article Save([FromBody]Article a)
        {
            return this.repo.Save(a);
        }

        [HttpPut]
        [Route("")]
        public Article Update([FromBody]Article a)
        {
            return this.repo.Update(a);
        }
    }
}