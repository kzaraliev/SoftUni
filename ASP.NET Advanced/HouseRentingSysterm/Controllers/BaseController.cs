using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSysterm.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
