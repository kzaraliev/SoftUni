using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Identity.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
