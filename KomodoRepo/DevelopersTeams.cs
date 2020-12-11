using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
   public class DevelopersTeams
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developers> DevTeamMembers { get; set; } = new List<Developers>();

        public DevelopersTeams() { }
        public DevelopersTeams(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
