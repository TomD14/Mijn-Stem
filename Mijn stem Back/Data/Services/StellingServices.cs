using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Mijn_stem_Back.Data.Services
{
    public class StellingServices
    {
        private readonly IMongoCollection<Stelling> _stellingen;

        public StellingServices(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseName"]);

            _stellingen = database.GetCollection<Stelling>(configuration["CollectionName"]);
        }

        public List<Stelling> Get() =>
            _stellingen.Find(stelling => true).ToList();

        public Stelling Get(string id) =>
            _stellingen.Find<Stelling>(stelling => stelling.StellingId == id).FirstOrDefault();

        public Stelling Create(Stelling stelling)
        {
            _stellingen.InsertOne(stelling);
            return stelling;
        }

        public void Update(string id, Stelling stellingIn) =>
            _stellingen.ReplaceOne(stelling => stelling.StellingId == id, stellingIn);

        public void RemoveStelling(Stelling stellingIn) =>
            _stellingen.DeleteOne(stelling => stelling.StellingId == stellingIn.StellingId);

        public void Remove(string id) =>
            _stellingen.DeleteOne(stelling => stelling.StellingId == id);

        public StellingAntwoord CreateAntwoord(string stellingId, StellingAntwoord stellingAntwoord)
        {
            var itemFilter = Builders<Stelling>.Filter.Eq(v => v.StellingId, stellingId);

            var updateBuilder = Builders<Stelling>.Update.AddToSet(Stelling => Stelling.Antwoorden, stellingAntwoord);

            _stellingen.UpdateOne(itemFilter, updateBuilder, new UpdateOptions() { IsUpsert = true });
            return stellingAntwoord;
        }

        public List<Stelling> GetType(string Type) =>
            _stellingen.Find<Stelling>(stelling => stelling.Type == Type).ToList();
    }
}
