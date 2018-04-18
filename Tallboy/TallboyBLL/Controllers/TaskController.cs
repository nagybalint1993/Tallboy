using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL.Models;

namespace TallboyBLL.Controllers
{
    public class TaskController
    {
        private const string actionName = "task";

        public TaskController()
        {
        }

        //return with the tasks
        public async Task<List<TallboyBLL.Models.Task>> GetTasksAsync(Action<List<Models.Task>> getTasksCallback)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            Uri requestUri = new Uri(NetworkSettings.ApiURL + "/" + actionName);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";
            List<TallboyBLL.Models.Task> tasks = null;

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<Models.Task>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            //Callback
            getTasksCallback(tasks);

            return tasks;
        }
    }
}
