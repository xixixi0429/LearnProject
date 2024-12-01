using Microsoft.AspNetCore.Mvc;

namespace LearnRecordAPI.Controllers.View
{
    public class LearnRecordController : Controller
    {
        public IActionResult Index()
        {
            return View("LearnRecord");
        }
    }
}
