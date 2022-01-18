using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Data.Services.Interfaces;
using Mijn_stem_Back.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services
{
    public class AntwoordServices : IAntwoordServices
    {
        private readonly IMongoCollection<Stelling> _stellingen;

        public AntwoordServices(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseName"]);

            _stellingen = database.GetCollection<Stelling>(configuration["CollectionName"]);
        }

        public async Task<StellingAntwoord> CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord)
        {
            var itemFilter = Builders<Stelling>.Filter.Eq(v => v.StellingId, stellingId);

            var updateBuilder = Builders<Stelling>.Update.AddToSet(Stelling => Stelling.Antwoorden, stellingAntwoord);

            await _stellingen.UpdateOneAsync(itemFilter, updateBuilder, new UpdateOptions() { IsUpsert = true});
            return stellingAntwoord;
        }

        public async Task<StellingAntwoord> CheckUser(string userId, string stellingId)
        {
            var stelling = await _stellingen.Find(stelling => stelling.StellingId == stellingId).FirstAsync();
            if(stelling.Antwoorden != null)
            {
                var result = stelling.Antwoorden.Find(antwoord => antwoord.UserId == userId);
                return result;
            }
            return null;
        }

        public async Task<List<Stelling>> GetType(string Type) =>
        await _stellingen.Find(stelling => stelling.Type == Type).ToListAsync();
    }
}
