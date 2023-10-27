using InveonTestMVC.web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InveonTestMVC.web.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = new List<Book>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7051/api/Book"))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(gelenString);
                }
            }

            return View(books);
        }

        public async Task<IActionResult> EditBook(int id)
        {
            // TODO : Edit EditBook method
            var book = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7051/api/Book/{id}"))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(gelenString);
                }
            }
            return View(book);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            var book = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7051/api/Book/{id}"))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(gelenString);
                }
            }
            return View(book);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            // TODO : Edit DeleteBook method
            var book = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7051/api/Book/{id}"))
                {
                    string gelenString = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(gelenString);
                }
            }
            return View(book);
        }

        public async Task<IActionResult> CreateBook()
        {
            return View();
        }
    }
}
