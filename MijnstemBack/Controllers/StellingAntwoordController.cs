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
            var stelling = _stellingService.GetById(id);

            if (stelling == null)
            {
                return NotFound();
            }

            if (stelling.Result.Antwoorden.Find(a => a.UserId == stellingAntwoordIn.UserId) == null) 
            {
                _stellingService.CreateAntwoord(id, stellingAntwoordIn);

            }
            
            return NoContent();
        }

        [HttpGet("{type}, {userId}", Name = "GetStellingType")]
        public async Task<ActionResult<List<Stelling>>> Get(string type, string userId)
        {
            List<Stelling> stellingen = await _antwoordServices.GetType(type);

            if (stellingen == null)
            {
                return NotFound();
            }

            List<Stelling> Resultaat = stellingen.Where(stelling => stelling.Antwoorden.Where(a => a.UserId == userId).ToList().Count == 0).ToList();

            return Resultaat;
        }

        
    }
}
