[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Providers.WebApiProvider))]
namespace MoviesPocketXForms.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MoviesPocketXForms.Models;
    using MoviesPocketXForms.Services;
    using Newtonsoft.Json;
    using Xamarin.Forms;

    public class WebApiProvider : IWebApiProvider
    {
        private const string NOW_PLAYING_URL = "https://api.themoviedb.org/3/movie/now_playing?api_key=e8f58c65a7f1442fb4df99e10ae45604&language=es-ES&page=1";

        private IHttpService httpService;

        public WebApiProvider()
        {
            httpService = DependencyService.Get<IHttpService>();
        }

        public async Task<IEnumerable<MyMedia>> GetMediaListAsync()
        {
            string url = $"{NOW_PLAYING_URL}";

            var result = await httpService.GetAsync<Dictionary<string, object>>(url);

            //System.Diagnostics.Debug.WriteLine("\n\nResult: " + result + "\n\n");

            var results = result["results"];

            //System.Diagnostics.Debug.WriteLine("\n\nResults: " + results + "\n\n");

            var items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<MyMedia>>(results.ToString()));

			//System.Diagnostics.Debug.WriteLine("\n\nItems: " + items[0].Title + "\n\n");

            return items;
        }

		public async Task<IEnumerable<Cinema>> GetCinemaListAsync(string url)
		{
			var result = await httpService.GetAsync<Dictionary<string, object>>(url);

			var results = result["results"];

			var items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Cinema>>(results.ToString()));

            //System.Diagnostics.Debug.WriteLine("\n\nItems: " + items.ToString() + "\n\n");
			return items;
		}
    }
}
