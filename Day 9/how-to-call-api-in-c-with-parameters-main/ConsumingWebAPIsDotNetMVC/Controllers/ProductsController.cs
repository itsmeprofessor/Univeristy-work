using ConsumingWebAPIsDotNetMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumingWebAPIsDotNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        private static string url = "https://localhost:7263/api/Products";
        private Uri baseUri = new Uri(url);
        private readonly HttpClient _httpClient;
        public ProductsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseUri;
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(baseUri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                return View(products);
            }
            return View(new List<Product>());
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            string jsonProduct = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = _httpClient.PostAsync(baseUri, content).Result;
            if (respone.IsSuccessStatusCode)
            {
                //string responseJons = respone.Content.ReadAsStringAsync().Result;
                TempData["message"] = "Product added successfully";
                TempData["messageType"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = "Product not added successfully";
            TempData["messageType"] = "error";
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"{baseUri}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Product product = JsonConvert.DeserializeObject<Product>(json);
                return View(product);
            }
            TempData["message"] = "Product not found";
            TempData["messageType"] = "error";
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            string json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync($"{baseUri}/{product.Id}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["message"] = "Product edited successfully";
                TempData["messageType"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = "Product not edited successfully";
            TempData["messageType"] = "error";
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync($"{baseUri}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["message"] = "Product Delete successfully";
                TempData["messageType"] = "success";
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = "Product not Delete successfully";
            TempData["messageType"] = "error";
            return RedirectToAction(nameof(Index));
        }
    }
}
