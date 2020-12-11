using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
   public class DevelopersTeamsRepository
    {

        private readonly DevelopersRepository _developerRepo = new DevelopersRepository(); // access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevelopersTeams> _devTeams = new List<DevelopersTeams>();

        //DevTeam Create
        public void AddDevsTeamToList(DevelopersTeams devTeam)
        {
            _devTeams.Add(devTeam);
        }

        //DevTeam Read
        public List<DevelopersTeams> GetDevTeamsList()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool updateExistingDevsTeams(string originalID, DevelopersTeams newID)
        {
            //Find the content
            DevelopersTeams oldID = GetDevsTeamByID(originalID);

            //Update the content
            if (oldID != null)
            {
                oldID.TeamName = newID.TeamName;
                oldID.TeamID = newID.TeamID;
                oldID.DevTeamMembers = newID.DevTeamMembers;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveDevTeamFromList(string iD)
        {
            DevelopersTeams devTeam = GetDevTeamByID(iD);

            if (devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)

        public DevelopersTeams getDeveloperTeamsByID(string iD)
        {
            foreach (DevelopersTeams devTeam in _devTeams)
            {
                if (devTeam.TeamID.ToLower() == iD.ToLower())
                {
                    return devTeam;
                }
            }

            return null;
        }
    }
}
