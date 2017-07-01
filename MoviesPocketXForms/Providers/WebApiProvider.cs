[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Providers.WebApiProvider))]
namespace MoviesPocketXForms.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MoviesPocketXForms.Models;
    using MoviesPocketXForms.Services;
    using Xamarin.Forms;

    public class WebApiProvider : IWebApiProvider
    {
        private const string NOW_PLAYING_URL = "https://api.themoviedb.org/3/movie/now_playing?api_key=e8f58c65a7f1442fb4df99e10ae45604&language=es-ES&page=1";

        private IHttpService httpService;

        public WebApiProvider()
        {
            httpService = DependencyService.Get<IHttpService>();
        }

        public async Task<IList<Media>> GetMediaList()
        {
            string url = $"{NOW_PLAYING_URL}";

            var result = await httpService.GetAsync<IList<Media>>(url);

            return result;
        }


    }
}
