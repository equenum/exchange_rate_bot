using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
    }
}
