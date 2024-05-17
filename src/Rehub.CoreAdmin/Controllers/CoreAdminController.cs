using Microsoft.AspNetCore.Mvc;

namespace ReHub.CoreAdmin.Controllers
{
    [CoreAdminAuth]
    public class CoreAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
