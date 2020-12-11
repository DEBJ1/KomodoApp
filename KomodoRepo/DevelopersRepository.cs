using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class DevelopersRepository
    {




        private readonly List<Developers> _developerDirectory = new List<Developers>();


        //Create
        public void AddDeveloperToList(Developers developer)
        {
            _developerDirectory.Add(developer); //Fields have underscores. Properties don't
        }

        //Read
        public List<Developers> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Update
        public bool UpdateExistingDeveloper(string originalID, Developers newID)
        {
            //Find content
            Developers oldID = GetDeveloperByID(originalID);

            //Update content
            if (oldID != null)
            {
                oldID.Name = newID.Name;
                oldID.IDNumber = newID.IDNumber;
                oldID.HasPluralSightAccess = newID.HasPluralSightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(string iD)
        {
            Developers developer = GetDeveloperByID(iD);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get Developer by ID
        public Developers GetDeveloperByID(string iD)
        {
            foreach (Developers developer in _developerDirectory)
            {
                if (developer.IDNumber == iD)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}

