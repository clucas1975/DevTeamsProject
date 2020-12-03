using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string DeveloperName { get; set; }
        public int DevID { get; set; }
        public bool HasAccessToPluralsight { get; set; }

        public Developer() { }

        public Developer(string developerName, int devid, bool hasAccessToPluralsight)
        {
            DeveloperName = developerName;
            DevID = devid;
            HasAccessToPluralsight = hasAccessToPluralsight;

        }
    }
}
