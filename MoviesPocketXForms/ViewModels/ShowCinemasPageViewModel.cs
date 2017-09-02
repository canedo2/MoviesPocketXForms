namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Xamarin.Forms;
    using Models;
    using Providers;
    using System.Collections.ObjectModel;
	using System.Threading.Tasks;

    public class ShowCinemasPageViewModel: BaseViewModel
    {
		private IWebApiProvider webApiProvider;

        public ShowCinemasPageViewModel()
        {
			webApiProvider = DependencyService.Get<IWebApiProvider>();	
        }

		public void Init()
		{
			IsLoading = true;
		}

        public async Task<ObservableCollection<Cinema>> CinemasOnArea(double lng, double lat){
			var cinemaList = await webApiProvider.GetCinemaListAsync("https://maps.googleapis.com/maps/api/place/textsearch/json?query=cines&location=" + lat +","+ lng + "&radius=10000&key=AIzaSyAgAK9maR3XaoWd-C0paZhABb9rtT_hyi8");
            var pins = new ObservableCollection<Cinema>();

			foreach (Cinema cinema in cinemaList)
			{
				pins.Add(cinema);
				//System.Diagnostics.Debug.WriteLine(cinema);

			}
            return pins;
        }
	}
}
