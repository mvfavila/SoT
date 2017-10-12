using SoT.Infra.Data.Interfaces;
using System.Web;

namespace SoT.Infra.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";

        public SoTContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new SoTContext();
            }

            return (SoTContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
