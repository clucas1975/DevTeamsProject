using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private List<Developer> _developerDirectory = new List<Developer>();

        //Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);

        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Update
        public bool UpdateExistingDeveloper(string originalName, Developer newDeveloper)
        {
            //Find the name
            Developer oldDeveloper = GetDeveloperByName(originalName);

            //Update name
            if (oldDeveloper != null)
            {
                oldDeveloper.DeveloperName = newDeveloper.DeveloperName;
                oldDeveloper.DevID = newDeveloper.DevID;
                oldDeveloper.HasAccessToPluralsight = newDeveloper.HasAccessToPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDeveloperFromList(string name)
        {

            Developer developer = GetDeveloperByName(name);
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

        //Helper Method
        public Developer GetDeveloperByName
            (string name)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.DeveloperName.ToLower() == name.ToLower())
                {
                    return developer;
                }


            }
            return null;
        }
    }
}
