using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services.Interfaces
{
    public interface IAntwoordServices
    {
        public StellingAntwoord CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord);
        public StellingAntwoord? CheckUser(string userId, string stellingId);
        public List<Stelling> GetType(string Type);

    }
}
