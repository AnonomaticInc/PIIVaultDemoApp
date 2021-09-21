using PIIVault.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PIIVaultDemoApp.Helpers
{
    public class HttpService
    {
        /* This class is strongly typed to the PII Vault. 
         * It provides everything you need from an http client to work with the PII Vault
         * 
         * You will want to ensure you have the PIIVault.Shared assembly included in your project
         * */

        private readonly HttpClient _httpClient;

        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpService(string BaseApiUrl)
        {
            /* When this class is created without a security token.
             * Can really only be used to get a security token
             */

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(BaseApiUrl),
            };
            _httpClient.Timeout = TimeSpan.FromSeconds(300);
        }

        public HttpService(string token, string BaseApiUrl = null)
        {
            /* When the security token has been recieved, recreate this http class with it
             */
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            if (BaseApiUrl != null)
            {
                _httpClient = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(BaseApiUrl)
                };
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ApiResponse> GetAsync(string requestUri)
        {
            return await ExecuteAsync(requestUri, "GET");
        }

        public async Task<ApiResponse> PostAsync(string requestUri, object data)
        {
            return await ExecuteAsync(requestUri, "POST", data);
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string requestUri, object data)
        {
            return await ExecuteAsync<T>(requestUri, "PUT", data);
        }

        public async Task<ApiResponse<T>> ForgetAsync<T>(string requestUri, object data)
        {
            return await ExecuteAsync<T>(requestUri, "FORGET", data);
        }

        public async Task<ApiResponse> PutAsync(string requestUri, object data)
        {
            return await ExecuteAsync(requestUri, "PUT", data);
        }

        public async Task<ApiResponse> UploadAsync(string requestUri, object data)
        {
            return await ExecuteAsync(requestUri, "UPLOAD", data);
        }

        public async Task<ApiResponse> DeleteAsync(string requestUri)
        {
            return await ExecuteAsync(requestUri, "DELETE");
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string requestUri)
        {
            return await ExecuteAsync<T>(requestUri, "GET");
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string requestUri, object data)
        {
            return await ExecuteAsync<T>(requestUri, "POST", data);
        }

        public async Task<ApiResponse<T>> UploadAsync<T>(string requestUri, object data)
        {
            return await ExecuteAsync<T>(requestUri, "UPLOAD", data);
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string requestUri)
        {
            return await ExecuteAsync<T>(requestUri, "DELETE");
        }

        private async Task<ApiResponse> ExecuteAsync(string requestUri, string httpMethod, object data = null)
        {
            try
            {
                var httpResponseMessage = await GetHttpResponseMessageAsync(requestUri, httpMethod, data);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await Deserialize<ApiResponse>(httpResponseMessage, defaultJsonSerializerOptions);
                }
                else
                {
                    var response = new ApiResponse();

                    response.SetError(httpResponseMessage.ReasonPhrase, await httpResponseMessage.Content.ReadAsStringAsync());

                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResponse();

                response.SetError(ex);

                return response;
            }
        }

        private async Task<ApiResponse<T>> ExecuteAsync<T>(string requestUri, string httpMethod, object data = null)
        {
            try
            {
                var httpResponseMessage = await GetHttpResponseMessageAsync(requestUri, httpMethod, data);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await Deserialize<ApiResponse<T>>(httpResponseMessage, defaultJsonSerializerOptions);
                }
                else
                {
                    var response = new ApiResponse<T>();

                    response.SetError(httpResponseMessage.ReasonPhrase, await httpResponseMessage.Content.ReadAsStringAsync());

                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<T>();

                response.SetError(ex);

                return response;
            }
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessageAsync(string requestUri, string httpMethod, object data = null)
        {
            string dataJson = null;
            if (data != null && httpMethod != "UPLOAD")
            {
                dataJson = JsonSerializer.Serialize(data);
            }

            HttpResponseMessage httpResponseMessage;

            switch (httpMethod)
            {
                case "GET":
                    httpResponseMessage = await _httpClient.GetAsync(requestUri);
                    break;
                case "POST":
                    httpResponseMessage = await _httpClient.PostAsync(requestUri, new StringContent(dataJson, Encoding.UTF8, "application/json"));
                    break;
                case "PUT":
                    httpResponseMessage = await _httpClient.PutAsync(requestUri, new StringContent(dataJson, Encoding.UTF8, "application/json"));
                    break;
                case "UPLOAD":
                    httpResponseMessage = await _httpClient.PostAsync(requestUri, (HttpContent)data);
                    break;
                case "FORGET":
                    httpResponseMessage = await _httpClient.PutAsync(requestUri, new StringContent(dataJson, Encoding.UTF8, "application/json"));
                    break;
                case "DELETE":
                    httpResponseMessage = await _httpClient.DeleteAsync(requestUri);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Utility code not implemented for this Http method {0}", httpMethod));
            }

            return httpResponseMessage;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(responseString))
            {
                return JsonSerializer.Deserialize<T>(responseString, options);
            }

            return default;
        }
    }

}
