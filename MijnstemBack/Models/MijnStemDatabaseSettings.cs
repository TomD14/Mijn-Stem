using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Models
{
    public class MijnStemDatabaseSettings : IMijnStemDatabaseSettings
    {
        public string StellingenCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMijnStemDatabaseSettings
    {
        string StellingenCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

