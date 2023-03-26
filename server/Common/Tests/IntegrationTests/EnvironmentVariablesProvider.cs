namespace EShopModular.Common.IntegrationTests;

/// <summary>
/// For linux system we need to use EnvironmentVariableTarget.Process
/// https://learn.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-7.0
/// Set the variable in the terminal:
/// export ASPNETCORE_EShop_IntegrationTests_ConnectionString='...'
/// and run dotnet test from the same shell.
/// </summary>
public static class EnvironmentVariablesProvider
{
    public static string GetVariable(string variableName)
    {
#if  !LINUX
        var environmentVariable = Environment.GetEnvironmentVariable(variableName);
        
        if (!string.IsNullOrEmpty(environmentVariable))
        {
            return environmentVariable;
        }
        
        environmentVariable = Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.User);
        
        if (!string.IsNullOrEmpty(environmentVariable))
        {
            return environmentVariable;
        }
        
        return Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Machine) ??
               throw new InvalidOperationException();
#else
        return Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Process) ??
               throw new InvalidOperationException();
#endif
    }
}