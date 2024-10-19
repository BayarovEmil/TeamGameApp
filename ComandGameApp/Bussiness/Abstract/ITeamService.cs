using ComandGameApp.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.Bussiness.Abstract
{
    public interface ITeamService
    {
        void Add(DataTable entity);
        void GetAll();
        DataTable GetTable();
    }
}
