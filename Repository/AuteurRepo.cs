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
                                            && auteur.Mail == model.Mail
                                            );
        }

        public IQueryable<Auteur> FindAll()
        {
            // SELECT * FROM auteur;
            return this.context.Auteur;
        }

        public Auteur FindById(int id)
        {
            // SELECT * FROM auteur WHERE Id==id LIMIT 1;
            return this.context.Auteur
                .Where(auteur => auteur.Id == id)
                .First();
        }

        public void Remove(int id)
        {
            // DELETE auteur where ID = id;
            this.context.Remove(this.FindById(id));
            this.context.SaveChanges();
        }

        public Auteur Save(Auteur model)
        {
            // INSERT INTO auteur (nom, ...) VALUE (..., ..., ...)
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Auteur Update(Auteur model)
        {
            // UPDATE auteur SET nom=model.nom, prenom=model.prenom WHERE ID = model.id;
            this.context.Update(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
