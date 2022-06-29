using Microsoft.AspNetCore.Mvc;
using StackExchange.Exceptional;
using System.Threading.Tasks;

namespace Mabui.Finance.Controllers
{
    public class ShowErrorsController : Controller
    {
        public async Task Exceptions()
        {
            await ExceptionalMiddleware.HandleRequestAsync(HttpContext).ConfigureAwait(false);
        }
    }
}
