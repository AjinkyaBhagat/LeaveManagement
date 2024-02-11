using LeaveManagement.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Text;
using System.Text.Json;

namespace LeaveManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        
        //Get All Employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeDto> response = new List<EmployeeDto>();
            try
            {
                //Get All Regions from Web Api.
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7062/api/Employee");
                httpResponseMessage.EnsureSuccessStatusCode();
                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<EmployeeDto>>());
            }
            catch (Exception ex)
            {
                //Log exception
            }
            return View(response);
        }
        //Create Employee in DB.
        [HttpGet]
        [Route("Employee/Create")]
        public async Task<IActionResult> Create()
        {

            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            return View();
        }

        //Create Employee in DB.
        [HttpPost]
        [Route("Employee/Create")]
        public async Task<IActionResult> Create(AddEmployeerequestDto addEmployeerequestDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonContent = JsonSerializer.Serialize(addEmployeerequestDto);
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7062/api/Employee/Create"),
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<AddEmployeerequestDto>();

            if (response != null)
            {
                return RedirectToAction("Dashboard", "Employee");
            }
            return View();
        }

        //Login
        [HttpGet]
        [Route("Employee/Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        
        //Login Post Request
        [HttpPost]
        [Route("Employee/Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonContent = JsonSerializer.Serialize(loginDto);
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7062/api/Employee/Login"),
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            // httpResponseMessage.EnsureSuccessStatusCode();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var response = await httpResponseMessage.Content.ReadFromJsonAsync<LoginDto>();
                HttpContext.Session.SetString("UserSession", response.Email);
                HttpContext.Session.SetString("EmployeeIdSession", response.EmployeeId.ToString());
                return RedirectToAction("Dashboard", "Employee");
            }
            else
            {
                ViewBag.Message = "Login Faild..Please check Email or Password!!";
            }
            return View();
        }

        //Employee/Dashboard
        [HttpGet]
        [Route("Employee/Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                ViewBag.EmployeeId = HttpContext.Session.GetString("EmployeeIdSession").ToString();
            }
            else
            {
                return RedirectToAction("Login", "Employee");
            }
            return View();
        }

        //Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                 HttpContext.Session.Remove("UserSession");
                HttpContext.Session.Remove("EmployeeIdSession");

                return RedirectToAction("Login", "Employee");
            }
            return View();
        }



    }

}
