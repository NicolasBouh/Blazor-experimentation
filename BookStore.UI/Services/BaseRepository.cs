using BookStore.UI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HttpClient _client;

        public BaseRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Create(string url, T obj)
        {
            if (obj == null)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
                return true;

            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            if (id < 1)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}{id}");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        public async Task<T> Get(string url, int id)
        {
            if (id < 1)
                return null;

            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{id}");
            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return null;
        }

        public async Task<IList<T>> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<T>>(content);
            }

            return null;
        }

        public async Task<bool> Update(string url, T obj)
        {
            if (obj == null)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }
    }
}
