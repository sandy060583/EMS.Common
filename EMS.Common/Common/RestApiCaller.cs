using EMS.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace EMS.Common.Common
{
    public class RestApiCaller : IRestApiCaller
    {
        private void SetupClient(HttpClient client, string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress); ;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(10);

        }

        public T Get<T>(string baseAddress, string apiUrl)
        {
            T result = default(T);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                SetupClient(client, baseAddress);
                var response = client.GetAsync(apiUrl).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T>(responseData);
            }
            return result;
        }

        public T2 Post<T1, T2>(string baseAddress, string apiUrl, T1 postObject)
        {
            T2 result = default(T2);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                SetupClient(client, baseAddress);

                var myjsonobject = JsonConvert.SerializeObject(postObject);
                var data = new StringContent(myjsonobject, Encoding.UTF8, "application/json");
                var response = client.PostAsync(apiUrl, data).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T2>(responseData);
            }
            return result;
        }

        public T2 Put<T1, T2>(string baseAddress, string apiUrl, T1 putObject)
        {
            T2 result = default(T2);
            using (var client = new HttpClient())
            {
                SetupClient(client, baseAddress);
                var myjsonobject = JsonConvert.SerializeObject(putObject);
                var data = new StringContent(myjsonobject, Encoding.UTF8, "application/json");
                var response = client.PutAsync(apiUrl, data).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T2>(responseData);
            }
            return result;
        }

        public void Delete(string baseAddress, string apiUrl)
        {
            using (var client = new HttpClient())
            {
                SetupClient(client, baseAddress);
                var response = client.DeleteAsync(apiUrl).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
