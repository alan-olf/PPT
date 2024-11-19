using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.App.Core.Data.Store
{
    public interface IStore<T>
    {
        IQueryable<T> Query { get; }
    }
}
