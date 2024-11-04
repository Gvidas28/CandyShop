using RestSharp;
using System.Threading.Tasks;

namespace CandyShop.Mobile.Services
{
    public interface IClientService
    {
        string Customer { get; set; }
        int? CustomerId { get; set; }
        Task<Response> SendRequestToBackendAsync<Request, Response>(Request body, string path, Method method);
        Task<Response> SendRequestToBackendAsync<Response>(string path, Method method, string query = null);
    }
}