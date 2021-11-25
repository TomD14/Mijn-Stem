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

        public string Bescrhijving { get; set; }

        public int Keuze1 { get; set; }

        public int Keuze2 { get; set; }

        public int Keuze3 { get; set; }

        public int Keuze4 { get; set; }

        public int Keuze5 { get; set; }

    }
}
