using BiblioContext.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class GanreProviderApi : IGanreProvider
    {
        public Ganre Ganre { get; set; }
        HttpClient HttpClient { get; set; }

        public GanreProviderApi()
        {
            HttpClient = new();
        }

        public async Task CreateGanreAsync(Ganre ganre)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGanreAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public bool GanreExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ganre>> GetGanresAsync()
        {
            try
            {
                string url = $@"https://localhost:7093/api/Ganres";
                var response = await HttpClient.GetAsync(requestUri: url);
                return JsonConvert.DeserializeObject<IEnumerable<Ganre>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Ganre> GetGanreAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGanreAsync(Ganre ganre)
        {
            throw new NotImplementedException();
        }
    }
}
