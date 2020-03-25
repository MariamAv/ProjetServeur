using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class ArticleRepo : CrudRepo<Article>
    {
        private RevuesContext context;

        public ArticleRepo(RevuesContext context)
        {
            this.context = context;
        }
        public IQueryable<Article> Filter(Article model)
        {
            return this.context.Article.Where(article => article.Id == model.Id
                                            && article.Titre == model.Titre
                                            && article.Contenu == model.Contenu
                                            );
        }

        public IQueryable<Article> FindAll()
        {
            return this.context.Article.Select(article => article);
        }

        public Article FindById(int id)
        {
            return this.context.Article.Find(id);
        }

        public void Remove(int id)
        {
            Article model = this.FindById(id);
            this.context.Article.Remove(model);
        }

        public Article Save(Article model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Article Update(Article model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
