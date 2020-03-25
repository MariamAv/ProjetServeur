using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetServeur.Domaine;

namespace ProjetServeur.Controllers
{
    [Route("/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public ArticleController() { }
        public IEnumerable<Article> FindAll()
        {
            ICollection<Article> articles = new List<Article>();
            Article a1 = new Article()
            {
                Titre = "titre1",
                Contenu = "bla bla bla",
            };
            Article a2 = new Article()
            {
                Titre = "titre2",
                Contenu = "bla bla bla bla",
            };
            articles.Add(a1);
            articles.Add(a2);

            return articles;
        }
    }
}