using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data.Services
{
    public class AntwoordServices
    {
        private readonly IMongoCollection<Stelling> _stellingen;

        public AntwoordServices(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseName"]);

            _stellingen = database.GetCollection<Stelling>(configuration["CollectionName"]);
        }

        public StellingAntwoord CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord)
        {
            var itemFilter = Builders<Stelling>.Filter.Eq(v => v.StellingId, stellingId);

            var updateBuilder = Builders<Stelling>.Update.AddToSet(Stelling => Stelling.Antwoorden, stellingAntwoord);

            _stellingen.UpdateOne(itemFilter, updateBuilder, new UpdateOptions() { IsUpsert = true});
            return stellingAntwoord;
        }

        public StellingAntwoord? CheckUser(string userId, string stellingId)
        {
            var stelling = _stellingen.Find<Stelling>(stelling => stelling.StellingId == stellingId).FirstOrDefault();
            if(stelling.Antwoorden != null)
            {
                return stelling.Antwoorden.Find(antwoord => antwoord.UserId == userId);
            }
            return null;
        }

    }
}
