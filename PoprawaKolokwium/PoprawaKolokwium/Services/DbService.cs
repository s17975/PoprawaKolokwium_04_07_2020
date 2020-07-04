using PoprawaKolokwium.DTOs;
using PoprawaKolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Services
{
    public class DbService : IDbService
    {

        private readonly MyContext _someContext;

        public DbService(MyContext context)
        {
            _someContext = context;
        }

        public void AddFiretrackToAction(int idAction, int idFireTruck)
        {

            var contex = new MyContext();
            // Czy wóz istnieje ?
            try
            {
                int czyWozIstnieje = contex.FireTrucks
                    .Where(m => m.IdFiretruck == idFireTruck)
                    .FirstOrDefault()
                    .IdFiretruck;
            }
            catch (Exception ex)
            {
                throw new Exception("Wóz nie istnieje");
            }

            // Czy jest już przypisany ?
            try
            {
                int czyJestWolny = contex.Firetruck_Actions
                    .Where(m => m.IdFiretruck == idFireTruck)
                    .FirstOrDefault()
                    .IdFiretruck;
            } catch (Exception ex)
            {
                throw new Exception("Wóz nie istnieje bądź jest już przypisany do akcji");
            }
            // Czy akcja istnieje ?
            try
            {
                int czyAkcjaIstnieje = contex.Actions
                    .Where(m => m.IdAction == idAction)
                    .FirstOrDefault()
                    .IdAction;
            }
            catch (Exception ex)
            {
                throw new Exception("Akcja nie istnieje");
            }
            // Czy wóz potrzebuje i posiada specjalny sprzet ?

                bool czyPosiadaSpecEq = contex.FireTrucks
                    .Where(m => m.IdFiretruck == idFireTruck)
                    .FirstOrDefault()
                    .SpecialEquipment.Equals(contex.Actions
                    .Where(m => m.IdAction == idAction)
                    .FirstOrDefault()
                    .NeedSpecialEquipment);
            if (!czyPosiadaSpecEq)
            {
                throw new Exception("Wóz nie posiada specjalnego sprzętu");
            }
            // Przypisanie

            var newFiretruckAction = new Firetruck_Action();
            newFiretruckAction.IdAction = idAction;
            newFiretruckAction.IdFiretruck = idFireTruck;
            newFiretruckAction.AssigmentDate = DateTime.Now;

            contex.Attach(newFiretruckAction);
            contex.SaveChanges();
        }

        public ICollection<Response_FirefighterActions> Get_FirefighterActions(int idFirefighter)
        {
            var context = new MyContext();
            List<Response_FirefighterActions> response = new List<Response_FirefighterActions>();

            var actions = context.Actions
                .Join(context.Firefighter_Actions,
                f => f.IdAction,
                s => s.IdAction,
                (f, s) => new
                {
                    f,
                    s
                })
                .Select(r => new
                {
                    r.f.StartTime,
                    r.f.EndTime,
                    r.f.IdAction,
                    r.s.IdFirefighter
                })
                .Where(m => m.IdFirefighter == idFirefighter)
                .OrderByDescending(o => o.EndTime)
                .ToList();
            // Generalnie 'actions' jest już gotową kolekcją o którą pytamy i można by zwracać zwyczajnie 'IActionResult' z wartością 'actions',
            // 'Response_FirefighterActions' jest stworzony tutaj bardziej pokazowo pod kątem ewentuanego 'rozwoju' zapytania

            foreach (var row in actions)
            {
                response.Add(new Response_FirefighterActions { IdAction = row.IdAction, StartTime = row.StartTime, EndTime = row.EndTime});
            }

            if (response.Count == 0 || response == null)
            {
                throw new Exception("Brak 'idFirefighter' w bazie.");
            }

            return response;

        }
    }
}
