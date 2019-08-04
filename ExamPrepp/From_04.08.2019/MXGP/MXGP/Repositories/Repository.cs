using MXGP.Models;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : IRepositorable
    {
        private List<T> entities;

        public IReadOnlyCollection<T> Entities
        {
            get
            {
                return this.entities.AsReadOnly();
            }
           
        }
        public virtual void Add(T model)
        {
            this.entities.Add(model);
        }

        public Repository()
        {
            this.entities = new List<T>();
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Entities;
        }

        public T GetByName(string name)
        {
            T entity = entities.Where(e => e.Name == name).FirstOrDefault();
            return entity;
        }

        public bool Remove(T model)
        {
            if (entities.Contains(model))
            {
                entities.Remove(model);
                return true;
            }

            return false;
        }
    }
}
