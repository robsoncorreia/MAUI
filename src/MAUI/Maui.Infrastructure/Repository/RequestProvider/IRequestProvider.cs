namespace Maui.Infrastructure.Repository.RequestProvider
{
    public interface IRequestProvider
    {
        string? baseURL { get; }

        Task<TResult> GetAsync<TResult>(string uri, string token = "", Query.QueryParameters queryParameters = null);

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "");

        Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret);

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "");

        Task DeleteAsync(string uri, string token = "");
    }
}