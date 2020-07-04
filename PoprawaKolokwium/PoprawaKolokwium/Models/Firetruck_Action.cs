using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class Firetruck_Action
    {
        public int IdFiretruckAction { get; set; }
        public int IdFiretruck { get; set; }
        public int IdAction { get; set; }
        public DateTime AssigmentDate { get; set; }

        public Action Action { get; set; }
        public FireTruck FireTruck { get; set; }
    }
}
