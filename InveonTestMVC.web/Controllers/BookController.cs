using InveonTestMVC.web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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

        public async Task<IActionResult> EditBookPage(int id)
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

        public async Task<IActionResult> EditBook(Book book)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7051/api/Book", book))
                {
                    Debug.WriteLine(response.StatusCode.ToString());
                }
            }
            return RedirectToAction("Index");
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

        public async Task<IActionResult> DeleteBookPage(int id)
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
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7051/api/Book/{id}"))
                {
                    Debug.WriteLine(response.StatusCode.ToString() + " " + id);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateBookPage()
        {
            return View();
        }

        public async Task<IActionResult> CreateBook(Book book)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7051/api/Book", book))
                {
                    Debug.WriteLine(response.StatusCode.ToString());
                }
            }
            return RedirectToAction("Index");
        }
    }
}
