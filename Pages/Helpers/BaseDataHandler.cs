using System.Web;
using System.Web.Routing;

namespace Store.Pages.Helpers
{
    public class BaseDataHandler<T> : IRouteHandler
                        where T : IHttpHandler, new()
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new T();
        }
    }
}