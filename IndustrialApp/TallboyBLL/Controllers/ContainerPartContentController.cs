using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TallboyBLL.Controllers
{
    public class ContainerPartContentController
    {
        DataContractJsonSerializer serializer;
        private const string actionName = "ContainerPartContent";

        public ContainerPartContentController()
        {
            serializer = new DataContractJsonSerializer(typeof(Models.ContainerPartContent));
        }


        //return the ContainerPartContents which have reference to the Type with the given typeId
        public async Task<List<TallboyBLL.Models.ContainerPartContent>> GetContainerPartContentAsync(int typeId)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            Uri requestUri = new Uri(NetworkSettings.ApiURL + "/" + actionName + "/" + typeId.ToString());

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            List<TallboyBLL.Models.ContainerPartContent> containerPartContent = null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                containerPartContent = JsonConvert.DeserializeObject<List<Models.ContainerPartContent>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return containerPartContent;
        }

    }
}
