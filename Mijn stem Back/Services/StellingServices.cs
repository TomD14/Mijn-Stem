using Mijn_stem_Back.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Mijn_stem_Back.Services
{
    public class StellingServices
    {
        private readonly IMongoCollection<Stelling> _stellingen;

        public StellingServices(IMijnStemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stellingen = database.GetCollection<Stelling>(settings.BooksCollectionName);
        }

        public List<Stelling> Get() =>
            _stellingen.Find(book => true).ToList();

        public Stelling Get(string id) =>
            _stellingen.Find<Stelling>(stelling => stelling.StellingId == id).FirstOrDefault();

        public Stelling Create(Stelling stelling)
        {
            _stellingen.InsertOne(stelling);
            return stelling;
        }

        public void Update(string id, Stelling stellingIn) =>
            _stellingen.ReplaceOne(stelling => stelling.StellingId == id, stellingIn);

        public void Remove(Stelling stellingIn) =>
            _stellingen.DeleteOne(stelling => stelling.StellingId == stellingIn.StellingId);

        public void Remove(string id) =>
            _stellingen.DeleteOne(stelling => stelling.StellingId == id);
    }
}
