using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijn_stem_Back.Data
{
    public interface IDbContext
    {
        IQueryable<T> Set<T>() where T : class;
    }
}
