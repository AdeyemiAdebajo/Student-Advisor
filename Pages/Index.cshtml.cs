using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdvisor.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentAdvisor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Register> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public string FirstName { get; set; } = "User";
        public string WeatherDescription { get; set; } = "Loading weather...";

        public IndexModel(UserManager<Register> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                FirstName = user.FirstName;
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetStringAsync(
                    "http://api.openweathermap.org/data/2.5/weather?q=North+Bay&appid=9d0c1e5524c8f5e87b8e6d631fc081cd&units=metric");

                using var jsonDoc = JsonDocument.Parse(response);
                var weather = jsonDoc.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();
                var temp = jsonDoc.RootElement.GetProperty("main").GetProperty("temp").GetDecimal();

                WeatherDescription = $"{weather}, {temp}°C";
            }
            catch
            {
                WeatherDescription = "Weather info not available.";
            }
        }
    }
}
