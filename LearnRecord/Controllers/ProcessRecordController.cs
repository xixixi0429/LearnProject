using Microsoft.AspNetCore.Mvc;

namespace LearnRecordAPI.Controllers
{
    public class ProcessRecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
