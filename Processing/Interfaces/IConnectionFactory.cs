using System.Data;

namespace Processing
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
