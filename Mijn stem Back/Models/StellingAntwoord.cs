using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mijn_stem_Back.Models
{
    public class StellingAntwoord
    {
        public string UserId { get; set; }

        public string Antwoord { get; set; }
    }
}
