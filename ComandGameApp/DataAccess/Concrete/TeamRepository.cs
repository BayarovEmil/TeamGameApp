using ComandGameApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.DataAccess
{
    public class TeamRepository : IDataRepository<Team>
    {
        DataTable dataTable;
        string teamPath = "C:\\Users\\LENOVO\\source\\repos\\ComandGameApp\\ComandGameApp\\teams.json";
        string scorePath = "C:\\Users\\LENOVO\\source\\repos\\ComandGameApp\\ComandGameApp\\score.json";
        public TeamRepository(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }
        public void Add(DataTable entity)
        {
            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
            File.WriteAllText(scorePath, json);
        }

        public DataTable GetTable()
        {
            string readJson = File.ReadAllText(teamPath);
            DataTable readData = JsonConvert.DeserializeObject<DataTable>(readJson);
            return readData;
        }

        Team IDataRepository<Team>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
