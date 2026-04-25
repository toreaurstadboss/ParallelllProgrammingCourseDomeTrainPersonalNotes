using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples
{
  
    public class TaskWhenAllExample1 : IRunAsyncDemo
    {

        public async Task RunAsyncDemo()
        {
            var client = new HttpClient();

            var httpResponseMessages = new List<Task<HttpResponseMessage>>(); 
            Task<HttpResponseMessage> getSwedenTask = client.GetAsync("https://restcountries.com/v3.1/name/sweden");
            Task<HttpResponseMessage> getNorwayTask = client.GetAsync("https://restcountries.com/v3.1/name/sweden");
            Task<HttpResponseMessage> getFinlandTask = client.GetAsync("https://restcountries.com/v3.1/name/finland");

            httpResponseMessages.AddRange(new[]
            {
                getFinlandTask,
                getSwedenTask,
                getNorwayTask
            });

            await Task.WhenAll(httpResponseMessages);

            Console.WriteLine($"getNorwayTask: {getNorwayTask.Result.StatusCode} getSwedenTask: {getSwedenTask.Result.StatusCode} getFinlandTask: {getFinlandTask.Result.StatusCode} " );

            foreach (Task<HttpResponseMessage> responseMessage in httpResponseMessages)
            {
                using var response = await responseMessage;
                var responseContentString = JsonNode.Parse(await response.Content.ReadAsStringAsync());
                Console.WriteLine(responseContentString);
            }

        }

    }

}
