using System;
using System.Data;

namespace Processing
{
    public interface IDatabaseSource
    {
        T Call<T>(Func<IDbConnection, T> action, string cacheKey = null, DateTimeOffset? absoluteExperation = null);
    }
}
