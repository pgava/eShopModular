namespace EShopModular.Common.Domain;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}