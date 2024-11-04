using CandyShop.Mobile.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CandyShop.Mobile.Services
{
    public class ClientService : IClientService
    {
        private const string BASE_URL = "http://10.0.2.2:5137/";

        public string Customer { get; set; }
        public int? CustomerId { get; set; }

        public async Task<Response> SendRequestToBackendAsync<Request, Response>(Request body, string path, Method method)
        {
            var url = new UriBuilder(BASE_URL);
            url.Path += path;

            var client = new RestClient();
            var request = new RestRequest(url.Uri, method);
            request.AddBody(body);

            var res = await client.ExecuteAsync(request);
            if (res?.StatusCode != HttpStatusCode.OK)
                throw new CommunicationException($"Failed to communicate with backend API! (StatusCode: {res?.StatusCode}, Content: {res?.Content})");

            return JsonConvert.DeserializeObject<Response>(res.Content);
        }

        public async Task<Response> SendRequestToBackendAsync<Response>(string path, Method method, string query = null)
        {
            var url = new UriBuilder(BASE_URL);
            url.Path += path;
            if (!string.IsNullOrWhiteSpace(query))
                url.Query += query;

            var client = new RestClient();
            var request = new RestRequest(url.Uri, method);

            var res = await client.ExecuteAsync(request);
            if (res?.StatusCode != HttpStatusCode.OK)
                throw new CommunicationException($"Failed to communicate with backend API! (StatusCode: {res?.StatusCode}, Content: {res?.Content})");

            return JsonConvert.DeserializeObject<Response>(res.Content);
        }
    }
}