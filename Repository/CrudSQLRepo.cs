using Microsoft.EntityFrameworkCore;
using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class CrudSQLRepo<T> : CrudRepo<T> where T : Model
    {
        private RevuesContext context = null;
        private DbSet<T> table = null;
        public CrudSQLRepo(RevuesContext context)
        {
            this.context = context;
            this.table = context.Set<T>(); // context.Chercheur;

        }

        public IQueryable<T> Filter(T model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            return this.table;
        }

        public T FindById(int id)
        {
            return this.table.Where(model => model.Id == id).First();
        }

        public void Remove(int id)
        {
            this.context.Remove(this.FindById(id));
            this.context.SaveChanges();
        }

        public T Save(T model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public T Update(T model)
        {
            this.context.Update(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
