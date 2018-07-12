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
    public class TaskElementController
    {
        private const string actionName = "taskelement";

        public TaskElementController()
        {
        }

        //return the ContainerPartContents which have reference to the Type with the given typeId
        public async Task<List<TallboyBLL.Models.TaskElement>> GetTaskElementsAsync(Action<List<TaskElement>> getTaskElementsCallback, int taskId)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            Uri requestUri = new Uri(NetworkSettings.ApiURL + "/" + actionName + "/" + taskId.ToString());

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            List<TallboyBLL.Models.TaskElement> taskelements = null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                taskelements = JsonConvert.DeserializeObject<List<Models.TaskElement>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            //Callback
            getTaskElementsCallback(taskelements);

            return taskelements;
        }
    }
}
