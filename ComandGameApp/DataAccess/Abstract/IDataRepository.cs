using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.DataAccess
{
    public interface IDataRepository<T> where T : class
    {
        void Add(DataTable entity);
        T GetAll();
        DataTable GetTable();
    }
}
