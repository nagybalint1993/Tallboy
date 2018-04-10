using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TallboyBLL.Controllers
{
    public class TypeController
    {
        public string description { get; set; }
        public Models.Type currentType { get; set; }

        DataContractJsonSerializer serializer;

        public TypeController()
        {
            description = "description";
            serializer = new DataContractJsonSerializer(typeof(Models.Type));
        }

        public void TryToGetType(int id)
        {
            GetTypeAsync(id);
        }

        public async Task<TallboyBLL.Models.Type> GetTypeAsync(int id)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            /*
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            */

            Uri requestUri = new Uri("http://localhost:49184/api/types/" + id.ToString());

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            TallboyBLL.Models.Type type= null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                type = JsonConvert.DeserializeObject<Models.Type>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            description = httpResponseBody;
            return type;
        }
    }
}
