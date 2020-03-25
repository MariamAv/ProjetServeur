using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class AuteurRepo : CrudRepo<Auteur>
    {
        private RevuesContext context;

        public AuteurRepo(RevuesContext context)
        {
            this.context = context;
        }

        public IQueryable<Auteur> Filter(Auteur model)
        {
            return this.context.Auteur.Where(auteur => auteur.Id == model.Id 
                                            && auteur.Nom == model.Nom 
                                            && auteur.Prenom == model.Prenom 
                                            && auteur.Mail == model.Mail);
        }

        public IQueryable<Auteur> FindAll()
        {
            return this.context.Auteur.Select(auteur => auteur);
        }

        public Auteur FindById(int id)
        {
            return this.context.Auteur.Find(id);
        }

        public void Remove(int id)
        {
            Auteur model = this.FindById(id);
            this.context.Auteur.Remove(model);
        }

        public Auteur Save(Auteur model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Auteur Update(Auteur model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
