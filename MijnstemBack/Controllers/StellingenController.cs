using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class StellingenController : ControllerBase
    {
        private readonly IStellingServices _stellingService;

        public StellingenController(IStellingServices stellingServices)
        {
            _stellingService = stellingServices;
        }

        [HttpGet]
        public async Task <ActionResult<List<Stelling>>> Get() =>
            await _stellingService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStelling")]
        public async Task<ActionResult<Stelling>> Get(string id)
        {
            var stelling = await _stellingService.GetById(id);

            if (stelling == null)
            {
                return NotFound();
            }

            return stelling;
        }

        [HttpPost]
        public ActionResult<Stelling> Create(Stelling stelling)
        {
            _stellingService.Create(stelling);

            return CreatedAtRoute("GetStelling", new { id = stelling.StellingId.ToString() }, stelling);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Stelling stellingIn)
        {
            var stelling = _stellingService.GetById(id);

            if (stelling == null)
            {
                return NotFound();
            }

            _stellingService.Update(id, stellingIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var stelling = await _stellingService.GetById(id);

            if (stelling == null)
            {
                return NotFound();
            }

            await _stellingService.Remove(stelling.StellingId);

            return Ok();
        }
    }
}
