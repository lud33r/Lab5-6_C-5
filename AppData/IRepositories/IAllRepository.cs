using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepository<T>
    {
        public IEnumerable<T> GetAllItem();
        public bool CreateItem(T item);
        public bool DeleteItem(T item);
        public bool UpdateItem(T item);
    }
}
