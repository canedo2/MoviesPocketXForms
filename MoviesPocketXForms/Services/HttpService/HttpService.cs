[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Services.HttpService))]
namespace MoviesPocketXForms.Services
{
	using Newtonsoft.Json;
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
                System.Diagnostics.Debug.WriteLine("getasyncservice antes");
                var response = await currentClient.GetAsync(uri);
                System.Diagnostics.Debug.WriteLine("getasyncservice despues");
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("success RESPONSE");
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Media>>(content);
                }
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
