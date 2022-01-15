using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mijn_stem_Back.Models
{
    public class Stelling
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StellingId { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; }

        public string Beschrijving { get; set; }

        public string Type { get; set; }

        public List<StellingAntwoord> Antwoorden { get; set; }

    }
}
