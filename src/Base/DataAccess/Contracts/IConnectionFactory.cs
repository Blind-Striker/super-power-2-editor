using System.Data;

namespace SuperPowerEditor.Base.DataAccess.Contracts
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}