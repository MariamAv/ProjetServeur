using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class NumeroRepo : CrudRepo<Numero>
    {
        private RevuesContext context;

        public NumeroRepo(RevuesContext context)
        {
            this.context = context;
        }
        public IQueryable<Numero> Filter(Numero model)
        {
            return this.context.Numero.Where(numero => numero.Id == model.Id
                                            && numero.Nombre == model.Nombre
                                            && numero.Annee == model.Annee
                                            && numero.Nbpages == model.Nbpages
                                            );
        }

        public IQueryable<Numero> FindAll()
        {
            return this.context.Numero.Select(numero => numero);
        }

        public Numero FindById(int id)
        {
            return this.context.Numero.Find(id);
        }

        public void Remove(int id)
        {
            Numero model = this.FindById(id);
            this.context.Numero.Remove(model);
        }

        public Numero Save(Numero model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Numero Update(Numero model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
