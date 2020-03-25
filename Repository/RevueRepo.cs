using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class RevueRepo : CrudRepo<Revue>
    {
        private RevuesContext context;

        public RevueRepo(RevuesContext context)
        {
            this.context = context;
        }
        public IQueryable<Revue> Filter(Revue model)
        {
            return this.context.Revue.Where(revue => revue.Id == model.Id
                                            && revue.Nom == model.Nom
                                            && revue.Periodicite == model.Periodicite
                                            && revue.Numero == model.Numero
                                            );
        }

        public IQueryable<Revue> FindAll()
        {
            return this.context.Revue.Select(revue => revue);
        }

        public Revue FindById(int id)
        {
            return this.context.Revue.Find(id);
        }

        public void Remove(int id)
        {
            Revue model = this.FindById(id);
            this.context.Revue.Remove(model);
        }

        public Revue Save(Revue model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Revue Update(Revue model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
