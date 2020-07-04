using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class FireTruck
    {
        public int IdFiretruck { get; set; }
        public string OperationalNumber { get; set; }
        public bool SpecialEquipment { get; set; }

        public ICollection<Firetruck_Action> Firetruck_Actions { get; set; }
    }
}
