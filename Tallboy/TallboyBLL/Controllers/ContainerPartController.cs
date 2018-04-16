using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL.Models;

namespace TallboyBLL.Controllers
{
    public class ContainerPartController
    {
        private const string actionName = "ContainerPart";

        public ContainerPartController()
        {
            
        }

        //return the ContainerPart with the given Id
        public async Task<TallboyBLL.Models.ContainerPart> GetContainerPartAsync(int id)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            Uri requestUri = new Uri(NetworkSettings.ApiURL + "/" + actionName + "/" + id.ToString());

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            TallboyBLL.Models.ContainerPart containerPartContent = null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                containerPartContent = JsonConvert.DeserializeObject<Models.ContainerPart>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return containerPartContent;
        }


        // !!!! TODO now this method get all containerpart
        internal async System.Threading.Tasks.Task<List<ContainerPart>> GetContainerPartAsync(Action<List<ContainerPart>> getContainerPartsCallback, int v)
        {
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            Uri requestUri = new Uri(NetworkSettings.ApiURL + "/" + actionName);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            List<ContainerPart> containerPartContent = null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                containerPartContent = JsonConvert.DeserializeObject<List<ContainerPart>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            getContainerPartsCallback(containerPartContent);
            return containerPartContent;
        }
    }
}
