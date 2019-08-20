using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppJaveriana.Services
{
    public class APIService
    {
        private HttpClient client;
        private string URL;

        public APIService()
        {
            client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization
            //             = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
        }

        public async Task<JObject> testCallSingle(string url)
        {
            client = new HttpClient();
            URL = url;
            string content = await client.GetStringAsync(URL);
            JObject json = JObject.Parse(content);
            return json;
        }

        public async Task<JArray> testCallHeaderArray(string url,string arg)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-t6519fdd1s5q", arg);
            URL = url;
            string content = await client.GetStringAsync(URL);
            JArray answer = JArray.Parse(content);
            return answer;
        }
    }
}
