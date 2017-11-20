using System.Collections.Generic;

namespace SportUnite.BLL
{
    public interface IManager<T>
    {
        bool Delete(T t);

        IEnumerable<T> Get();

        T Get(int id);

        bool Save(T t);
    }
}
