using Maui.Infrastructure.Configuration.SqlServer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http.Headers;

namespace Maui.Infrastructure.Repository.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        private readonly Lazy<HttpClient> _httpClient =
            new(() =>
            {
                HttpClient httpClient = new();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            },
                LazyThreadSafetyMode.ExecutionAndPublication);

        public string? baseURL { get; private set; }

        public RequestProvider()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<MauiContext>().Build();

            baseURL = config["BaseURL"];

            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(token);

            HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

            Validate(response);

            await HandleResponse(response).ConfigureAwait(false);

            string serialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            StringContent content = new(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);

            Validate(response);

            await HandleResponse(response).ConfigureAwait(false);

            string serialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);

            return result;
        }

        private static void Validate(HttpResponseMessage response)
        {
            _ = response.StatusCode switch
            {
                HttpStatusCode.InternalServerError => throw new Exception(response.Content.ToString()),
                _ => string.Empty
            };
        }

        public async Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret)
        {
            HttpClient httpClient = GetOrCreateHttpClient(string.Empty);

            if (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(clientSecret))
            {
                AddBasicAuthenticationHeader(httpClient, clientId, clientSecret);
            }

            StringContent content = new(data);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);

            Validate(response);

            await HandleResponse(response).ConfigureAwait(false);

            string serialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);

            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            StringContent content = new(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PutAsync(uri, content).ConfigureAwait(false);

            Validate(response);

            await HandleResponse(response).ConfigureAwait(false);

            string serialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);

            return result;
        }

        public async Task DeleteAsync(string uri, string token = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(token);

            _ = await httpClient.DeleteAsync(uri).ConfigureAwait(false);
        }

        private HttpClient GetOrCreateHttpClient(string token = "")
        {
            HttpClient httpClient = _httpClient.Value;

            httpClient.DefaultRequestHeaders.Authorization =
                !string.IsNullOrEmpty(token)
                    ? new AuthenticationHeaderValue("Bearer", token)
                    : null;

            return httpClient;
        }

        private static void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(parameter))
            {
                return;
            }

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }

        private static void AddBasicAuthenticationHeader(HttpClient httpClient, string clientId, string clientSecret)
        {
            if (httpClient == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
            {
                return;
            }

            //httpClient.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(clientId, clientSecret);
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                _ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.StatusCode is HttpStatusCode.Forbidden or
                        HttpStatusCode.Unauthorized)
                {
                    // throw new ServiceAuthenticationException(content);
                }

                //throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }
    }
}