using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoprawaKolokwium.Services;

namespace PoprawaKolokwium.Controllers
{

    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IDbService _dbService;

        public MyController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [Route("api/firefighters/{idFirefighter}/actions")]
        [HttpGet("{idFirefighter}/actions")]
        public IActionResult GetFirefighterActions(int idFirefighter)
        {
            try
            {
                return Ok(_dbService.Get_FirefighterActions(idFirefighter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [Route("api/actions/{idFireTruck}/fire-trucks")]
        [HttpPost("{idFireTruck}/fire-trucks")]
        public IActionResult AddFiretrackToAction(int idAction, int idFireTruck)
        {
            if (idAction<0 || idFireTruck < 0)
            {
                return BadRequest("Nieprawidłowe parametry żadania.");
            }
            else
            {
                try
                {
                    _dbService.AddFiretrackToAction(idAction, idFireTruck);
                    return Ok("Wóz został dodany do akcji.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Blad przy dodawaniu wozu : " + ex.Message.ToString());
                }
            }
        }
    }
}