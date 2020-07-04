using PoprawaKolokwium.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Services
{
    public interface IDbService
    {

        ICollection<Response_FirefighterActions> Get_FirefighterActions(int idFirefighter);

        public void AddFiretrackToAction(int idAction, int idFireTruck);
    }
}
