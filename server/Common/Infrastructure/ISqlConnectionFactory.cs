using System.Data;

namespace EShopModular.Common.Infrastructure;

public interface ISqlConnectionFactory
{
    IDbConnection? GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}