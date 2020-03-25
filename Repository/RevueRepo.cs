using ProjetServeur.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetServeur.Repository
{
    public class RevueRepo : CrudRepo<Revue>
    {
        public IQueryable<Revue> Filter(Revue model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Revue> FindAll()
        {
            throw new NotImplementedException();
        }

        public Revue FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Revue> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Revue Save(Revue model)
        {
            throw new NotImplementedException();
        }

        public Revue Update(Revue model)
        {
            throw new NotImplementedException();
        }
    }
}
