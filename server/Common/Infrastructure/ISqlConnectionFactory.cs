using System.Data;

namespace eShopModular.Common.Infrastructure;

public interface ISqlConnectionFactory
{
    IDbConnection? GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}