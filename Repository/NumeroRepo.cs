using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class NumeroRepo : CrudRepo<Numero>
    {
        public IQueryable<Numero> Filter(Numero model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Numero> FindAll()
        {
            throw new NotImplementedException();
        }

        public Numero FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Numero> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Numero Save(Numero model)
        {
            throw new NotImplementedException();
        }

        public Numero Update(Numero model)
        {
            throw new NotImplementedException();
        }
    }
}
