using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateBot.Utilities
{
    /// <summary>
    /// Represents an api-handler.
    /// </summary>
    public static class ApiHandler
    {
        /// <summary>
        /// Represents an http api-client
        /// </summary>
        public static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Initializes api-client.
        /// </summary>
        public static void InitializeApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets api-call results.
        /// </summary>
        /// <typeparam name="T">Target api-reply class.</typeparam>
        /// <param name="apiUrl">Api-call url.</param>
        /// <returns>Api-call results.</returns>
        public static async Task<T> GetAsync<T>(string apiUrl)
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync(apiUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    T responseContent = await response.Content.ReadAsAsync<T>();
                    Log.Information($"API-call, success: {apiUrl}");

                    return responseContent;
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Log.Error($"API-call, fail: {apiUrl} / { response.ReasonPhrase }");

                    return default;
                }
            }
        }
    }
}
