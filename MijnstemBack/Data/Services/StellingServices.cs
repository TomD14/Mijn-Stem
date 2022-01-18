using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Data.Services.Interfaces;
using Mijn_stem_Back.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mijn_stem_Back.Data.Services
{
    public class StellingServices : IStellingServices
    {
        private readonly IMongoCollection<Stelling> _stellingen;

        public StellingServices(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseName"]);

            _stellingen = database.GetCollection<Stelling>(configuration["CollectionName"]);
        }

        public async Task<List<Stelling>> Get() =>
            await _stellingen.Find(stelling => true).ToListAsync();

        public async Task<Stelling> GetById(string id) =>
            await _stellingen.Find(stelling => stelling.StellingId == id).FirstAsync();

        public async Task<Stelling> Create(Stelling stelling)
        {
            await _stellingen.InsertOneAsync(stelling);
            return stelling;
        }

        public async Task Update(string id, Stelling stellingIn)
        {
            await _stellingen.ReplaceOneAsync(stelling => stelling.StellingId == id, stellingIn);
        }

        public async Task RemoveStelling(Stelling stellingIn) =>
            await _stellingen.DeleteOneAsync(stelling => stelling.StellingId == stellingIn.StellingId);

        public async Task Remove(string id)
        {
            try
            {
                await _stellingen.DeleteOneAsync(stelling => stelling.StellingId == id);

            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
            }
        }

        public async Task<StellingAntwoord> CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord)
        {
            var itemFilter = Builders<Stelling>.Filter.Eq(v => v.StellingId, stellingId);

            var updateBuilder = Builders<Stelling>.Update.AddToSet(Stelling => Stelling.Antwoorden, stellingAntwoord);

            await _stellingen.UpdateOneAsync(itemFilter, updateBuilder, new UpdateOptions() { IsUpsert = true });
            return stellingAntwoord;
        }


    }
}
