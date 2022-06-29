using System.Data;

namespace eShopCmc.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection? GetOpenConnection();

        IDbConnection CreateNewConnection();

        string GetConnectionString();
    }
}