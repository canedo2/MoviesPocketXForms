[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Services.HttpService))]
namespace MoviesPocketXForms.Services
{
	using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
	using System.Net.Http;
	using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;
    using System;

    public class HttpService : IHttpService
	{
		private static HttpClient currentClient;

        public List<Media> Items { get; private set; }

        public HttpService()
		{
			if (currentClient == null)
				currentClient = new HttpClient();
		}

		public async Task<List<Media>> GetAsyncService<T>(string url)
		{
            Items = new List<Media>();
            var uri = new Uri(string.Format(url, string.Empty));
            
            try
            {
                var response = currentClient.GetStringAsync(uri);
                System.Diagnostics.Debug.WriteLine(response.Result + "\n COSAS CHULAS \n\n\n");
				
                JObject jsonObj = JObject.Parse(response.Result);
				Dictionary<string, object> dictObj = jsonObj.ToObject<Dictionary<string, object>>();

                var results = dictObj["results"];



                System.Diagnostics.Debug.WriteLine("Primer item de results(Dictionary) : \n\n" + results + "\n\n");

                Items = JsonConvert.DeserializeObject<List<Media>>(results.ToString());

                System.Diagnostics.Debug.WriteLine("\n\n" + Items[0].Overview + "\n\n");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPTION");
                System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("antes return");

            return Items;
            //  HttpResponseMessage response = await currentClient.GetAsync(url);
            //	return await ProcessResponse<T>(response);
        }

		public async Task<T> PostAsync<T>(string url, HttpContent content)
		{
			HttpResponseMessage response = await currentClient.PostAsync(url, content);
			return await ProcessResponse<T>(response);
		}

		private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
		{
            System.Diagnostics.Debug.WriteLine("ANTES RESPONSE");
            if (response.IsSuccessStatusCode)
			{
                System.Diagnostics.Debug.WriteLine("RESPONSE SUCCESS");
                string responseStr = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseStr);
			}

			return default(T);
		}

	}
}
