using System.Data;

namespace eShopModular.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection? GetOpenConnection();

        IDbConnection CreateNewConnection();

        string GetConnectionString();
    }
}