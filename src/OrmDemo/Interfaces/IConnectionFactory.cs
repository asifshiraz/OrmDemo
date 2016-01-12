using System.Data;

namespace OrmDemo.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
