using ComandGameApp.Bussiness.Abstract;
using ComandGameApp.DataAccess;
using ComandGameApp.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.Bussiness.Concrete
{
    public class TeamService : ITeamService
    {
        private IDataRepository<Team> _repository;
        public TeamService(DataTable dataTable)
        {
            this._repository = new TeamRepository(dataTable);
        }

        public void Add(DataTable entity)
        {
            _repository.Add(entity);
        }

        public void GetAll()
        {
            _repository.GetAll();
        }

        public DataTable GetTable()
        {
            return _repository.GetTable();
        }
    }
}
