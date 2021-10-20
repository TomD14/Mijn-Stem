using Microsoft.AspNetCore.Mvc;
using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Controllers
{
    public class StellingenConrtoller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Stelling> Get()
        {

            return (null);
        }
    }
}
