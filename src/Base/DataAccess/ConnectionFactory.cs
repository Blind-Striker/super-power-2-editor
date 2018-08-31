using System.Data;
using FirebirdSql.Data.FirebirdClient;
using SuperPowerEditor.Base.DataAccess.Contracts;

namespace SuperPowerEditor.Base.DataAccess
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connStr;

        public ConnectionFactory(string connStr)
        {
            _connStr = connStr;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var conn = new FbConnection(_connStr);
                return conn;
            }
        }
    }
}
