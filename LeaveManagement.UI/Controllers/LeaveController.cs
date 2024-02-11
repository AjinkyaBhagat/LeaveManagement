using LeaveManagement.UI.Models.Domain;
using LeaveManagement.UI.Models.DTO;
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

        //Get All Leaves of single emplyeee
        public async Task<IActionResult> EmployeeLeaves()
        {
            if (HttpContext.Session.GetString("UserSession") != null && (HttpContext.Session.GetString("EmployeeIdSession") != null))
            {
                var employeeIdSession = HttpContext.Session.GetString("EmployeeIdSession");
                var client = httpClientFactory.CreateClient();
                var response = await client.GetFromJsonAsync<List<Leave>>($"https://localhost:7062/api/Leave/GetById/{employeeIdSession.ToString()}");
                if (response != null)
                {
                    return View(response);
                }
                return View(null);
            }
            else
            {
                return RedirectToAction("Login", "Employee");
            }
            return View();
        }
    }
}

