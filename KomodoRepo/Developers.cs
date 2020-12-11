using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class Developers
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public bool HasPluralSightAccess { get; set; }

        public Developers() { }
        public Developers(string name, string iDNumber, bool hasPluralSightAccess)
        {
            Name = name;
            IDNumber = iDNumber;
            HasPluralSightAccess = hasPluralSightAccess;
        }
    }
}
