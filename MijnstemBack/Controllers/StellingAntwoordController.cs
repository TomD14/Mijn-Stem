using Microsoft.AspNetCore.Mvc;
using Mijn_stem_Back.Data.Services;
using Mijn_stem_Back.Data.Services.Interfaces;
using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StellingAntwoordController : ControllerBase
    {
        private readonly IStellingServices _stellingService;
        private readonly IAntwoordServices _antwoordServices;

        public StellingAntwoordController(IStellingServices stellingServices, IAntwoordServices antwoordServices)
        {
            _stellingService = stellingServices;
            _antwoordServices = antwoordServices;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, StellingAntwoord stellingAntwoordIn)
        {
            var stelling = _stellingService.Get(id);

            if (stelling == null)
            {
                return NotFound();
            }

            if (_antwoordServices.CheckUser(stellingAntwoordIn.UserId, id) == null) 
            {
                _stellingService.CreateAntwoord(id, stellingAntwoordIn);

            }
            
            return NoContent();
        }

        [HttpGet("{type}, {userId}", Name = "GetStellingType")]
        public ActionResult<List<Stelling>> Get(string type, string userId)
        {
            List<Stelling> stellingen = _antwoordServices.GetType(type).ToList();

            if (stellingen == null)
            {
                return NotFound();
            }

            List<Stelling> Resultaat = stellingen.Where(stelling => _antwoordServices.CheckUser(userId, stelling.StellingId) == null).ToList();

            return Resultaat;
        }

        
    }
}
