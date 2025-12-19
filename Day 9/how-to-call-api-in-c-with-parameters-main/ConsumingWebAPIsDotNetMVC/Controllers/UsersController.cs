using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumingWebAPIsDotNetMVC.Controllers
{
    public class UsersController : Controller
    {
        private static string url = "https://jsonplaceholder.typicode.com/users";
        private Uri baseUri = new Uri(url);
        private HttpClient _httpClient;
        public UsersController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseUri;
        }
        public IActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(baseUri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                return View(users);
            }
            return View(null);
        }
    }
    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string BusinessIn { get; set; }
    }
    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("suite")]
        public string Suite { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

    }

}
