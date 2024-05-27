 
using Microsoft.AspNetCore.Mvc;

namespace RestoranTemp.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
