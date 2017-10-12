using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        SoTContext GetContext();
    }
}
