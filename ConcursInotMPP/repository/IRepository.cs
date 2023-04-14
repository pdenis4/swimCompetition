using System.Collections.Generic;
using ConcursInotMPP.model;

namespace ConcursInotMPP.repository
{
    public interface IRepository<ID, E> where E : IHasId<ID>
    {
        void Add(E elem);
        E Delete(E elem);
        void Update(ID id, E elem);
        E FindOne(ID id);
        IEnumerable<E> FindAll();
    }
}
