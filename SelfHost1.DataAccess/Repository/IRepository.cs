using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost1.DataAccess.Repository
{
    public interface IRepository<T>
    {
        void Save(T instance);
        void Update(T instance);
        void Delete(T instance);

        T GetById(int id);

        List<T> GetAll();
    }
}
