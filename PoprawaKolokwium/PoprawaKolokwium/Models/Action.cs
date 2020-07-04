using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class Action
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }

        public ICollection<Firefighter_Action> Firefighter_Actions { get; set; }

        public ICollection<Firetruck_Action> Firetruck_Actions { get; set; }
    }
}
