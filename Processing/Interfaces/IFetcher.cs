using System.Collections.Generic;

namespace Processing
{
    public interface IFetcher<T>
    {
        IEnumerable<T> Fetch();
    }
    
    public interface IFetcher<T, K>
    {
        IEnumerable<T> Fetch(K search);
    }
}
