using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BookStore.Mvc.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostWithComplexTypeAsync(this HttpClient client, object parameter, Uri uri)
        {
            
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.PostAsJsonAsync(uri, parameter);
        }
    }
}