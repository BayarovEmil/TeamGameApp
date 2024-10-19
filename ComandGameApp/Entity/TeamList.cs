using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.Entity
{
    public class Team
    {
        public string Name1 { get; set; }
        public string Score1 { get; set; }
        public string Name2 { get; set; }
        public string Score2 { get; set; }

        public Team() { }

        public Team(string team1, string score1, string score2, string team2)
        {
            Name1 = team1;
            Score1 = score1;
            Score2 = score2;
            Name2 = team2;
        }
    }
}
