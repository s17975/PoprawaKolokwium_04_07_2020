using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class Firefighter
    {
        public int IdFirefighter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Firefighter_Action> Firefighter_Actions { get; set; }
    }
}
