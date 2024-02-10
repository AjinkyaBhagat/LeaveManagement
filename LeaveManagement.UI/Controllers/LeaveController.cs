using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.UI.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LeaveController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult GetLeavesById()
        {
            return View();
        }
    }
}
