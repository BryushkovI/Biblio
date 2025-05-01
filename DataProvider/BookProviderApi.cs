using BiblioContext.Model;
using Newtonsoft.Json;
using System.Net.Mime;
using System;
using System.Net.WebSockets;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

namespace DataProvider
{
    public class BookProviderApi : IBookPrivider
    {
        public Book Book { get; set; }
        HttpClient HttpClient { get; set; }

        public BookProviderApi()
        {
            HttpClient = new HttpClient();
        }
        public bool BookExists(int id)
        {

            try
            {
                string url = $@"https://localhost:7093/api/Books/{id}";
                var response = HttpClient.GetAsync(requestUri: url).Result;
                return JsonConvert.DeserializeObject<Book>(response.Content.ReadAsStringAsync().Result) != null;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task CreateBookAsync(Book book)
        {
            string url = $@"https://localhost:7093/api/Books";

            try
            {
                await HttpClient.PostAsync(requestUri: url,
                                               content: new StringContent(
                                                    JsonConvert.SerializeObject(book),
                                                    System.Text.Encoding.UTF8,
                                                    MediaTypeNames.Application.Json)
                                               );
            }
            catch (Exception ex)
            {
            }
        }

        public async Task DeleteBookAsync(int? id)
        {
            string url = $@"https://localhost:7093/api/Books/{id}";
            await HttpClient.DeleteAsync(url);
        }

        public async Task<Book> GetBookAsync(int? id)
        {
            try
            {
                string url = $@"https://localhost:7093/api/Books/{id}";
                var response = await HttpClient.GetAsync(requestUri: url);
                return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            try
            {
                string url = $@"https://localhost:7093/api/Books";
                var response = await HttpClient.GetAsync(requestUri: url);
                return JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            string url = $@"https://localhost:7093/api/Books/{book.Id}";

            try
            {
                await HttpClient.PutAsync(requestUri: url,
                                              content: new StringContent(JsonConvert.SerializeObject(book),
                                                                         System.Text.Encoding.UTF8,
                                                                         MediaTypeNames.Application.Json));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
