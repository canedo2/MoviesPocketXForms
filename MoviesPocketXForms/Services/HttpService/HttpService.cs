[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Services.HttpService))]
namespace MoviesPocketXForms.Services
{
	using Newtonsoft.Json;
	using System.Net.Http;
	using System.Threading.Tasks;

	public class HttpService : IHttpService
	{
		private static HttpClient currentClient;

		public HttpService()
		{
			if (currentClient == null)
				currentClient = new HttpClient();
		}

		public async Task<T> GetAsync<T>(string url)
		{
			HttpResponseMessage response = await currentClient.GetAsync(url);
			return await ProcessResponse<T>(response);
		}

		public async Task<T> PostAsync<T>(string url, HttpContent content)
		{
			HttpResponseMessage response = await currentClient.PostAsync(url, content);
			return await ProcessResponse<T>(response);
		}

		private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				string responseStr = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseStr);
			}

			return default(T);
		}
	}
}
