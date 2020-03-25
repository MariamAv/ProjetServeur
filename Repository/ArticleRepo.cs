using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class ArticleRepo : CrudRepo<Article>
    {
        public IQueryable<Article> Filter(Article model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindAll()
        {
            throw new NotImplementedException();
        }

        public Article FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Article Save(Article model)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article model)
        {
            throw new NotImplementedException();
        }
    }
}
