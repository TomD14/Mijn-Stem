using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services.Interfaces
{
    public interface IAntwoordServices
    {
        public Task<StellingAntwoord> CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord);
        public Task<StellingAntwoord> CheckUser(string userId, string stellingId);
        public Task<List<Stelling>> GetType(string Type);

    }
}
