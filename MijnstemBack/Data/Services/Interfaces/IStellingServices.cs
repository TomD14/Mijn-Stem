using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services.Interfaces
{
    public interface IStellingServices
    {
        public Task<List<Stelling>> Get();
        public Task<Stelling> GetById(string id);
        public Task<Stelling> Create(Stelling stelling);
        public Task Update(string id, Stelling stelling);
        public Task RemoveStelling(Stelling stelling);
        public Task Remove(string id);
        public Task<StellingAntwoord> CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord);
    }
}
