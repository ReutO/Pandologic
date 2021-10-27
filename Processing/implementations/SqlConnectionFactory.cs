using System;
using System.Data;
using System.Data.SqlClient;

namespace Processing
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly ISourceGetter<string> _connectionStringSource;

        public SqlConnectionFactory(ISourceGetter<string> connectionStringSource)
        {
            _connectionStringSource = connectionStringSource ?? throw new ArgumentNullException(nameof(connectionStringSource));
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionStringSource.Get());
        }
    }
}
