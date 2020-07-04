using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class Firefighter_Action
    {
        public int IdFirefighter { get; set; }

        public int IdAction { get; set; }

        public Firefighter Firefighter { get; set; }

        public Action Action { get; set; }
    }
}
