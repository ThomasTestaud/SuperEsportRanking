using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{
    interface IService<T>
    {
        T Add(T entity);
        T Get(int id);
        List<T> GetAll();
        void Update(int id, T entity);
        void Delete(int id);

    }
}
