using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    class DevelopersTeams
    {
        public string TeamName { get; set; }
        public string TeamID { get; set; }
        public List<Developers> DevTeamMembers { get; set; } = new List<Developers>();

        public DevelopersTeams() { }
        public DevelopersTeams(string teamName, string teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
