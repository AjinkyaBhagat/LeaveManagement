using LeaveManagement.UI.Models.Domain;
using LeaveManagement.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LeaveManagement.UI.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LeaveController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        //Get All Leaves of single employee
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

        //Create Leave in DB
        [HttpGet]
        [Route("Leave/Apply")]
        public IActionResult ApplyLeave()
        {

            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            ViewBag.EmpId =HttpContext.Session.GetString("EmployeeIdSession");
            ViewBag.LastNameSession = HttpContext.Session.GetString("LastNameSession");
            ViewBag.FirstNameSession = HttpContext.Session.GetString("FirstNameSession");
            ViewBag.LeavesAvailableSession = HttpContext.Session.GetString("LeavesAvailableSession");
            return View();
        }

        //Create Leave in DB
        [HttpPost]
        [Route("Leave/Apply")]
        public async Task<IActionResult> ApplyLeave(LeaveDto leaveDto,UpdateEmployeeDto updateEmployeeDto)
        {

            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            ViewBag.EmpId = HttpContext.Session.GetString("EmployeeIdSession");
            ViewBag.EmpFirstName = HttpContext.Session.GetString("FirstNameSession");
            ViewBag.EmpLastName = HttpContext.Session.GetString("LastNameSession");

            var client = httpClientFactory.CreateClient();
            var jsonContent = JsonSerializer.Serialize(leaveDto);
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7062/api/Leave/ApplyForLeave"),
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<LeaveDto>();
            
            if (response != null)
            {
                return RedirectToAction("EmployeeLeaves", "Leave");
            }
            return View();
        }
    }
}

