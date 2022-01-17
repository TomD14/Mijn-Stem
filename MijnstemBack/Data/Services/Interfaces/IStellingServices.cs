using Mijn_stem_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services.Interfaces
{
    public interface IStellingServices
    {
        public List<Stelling> Get();
        public Stelling Get(string id);
        public Stelling Create(Stelling stelling);
        public void Update(string id, Stelling stelling);
        public void RemoveStelling(Stelling stelling);
        public void Remove(string id);
        public StellingAntwoord CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord);
    }
}
