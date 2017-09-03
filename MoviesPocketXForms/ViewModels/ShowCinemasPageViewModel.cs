namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Xamarin.Forms;
    using Models;
    using Providers;
    using System.Collections.ObjectModel;
	using System.Threading.Tasks;
    using System.Windows.Input;
    public class ShowCinemasPageViewModel: BaseViewModel
    {
		private IWebApiProvider webApiProvider;
        private string searchString;
        public ICommand SearchButtonCommand { get; }

        public ShowCinemasPageViewModel()
        {
			webApiProvider = DependencyService.Get<IWebApiProvider>();
            SearchString = "Cines";
            SearchButtonCommand = new Command(() => sendSearch());
        }

		public void Init()
		{
			IsLoading = true;

            IsLoading = false;
		}

        public async Task<ObservableCollection<Cinema>> SearchOnArea(double lng, double lat){
            var locationList = await webApiProvider.GetCinemaListAsync("https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + SearchString + "&location=" + lat +","+ lng + "&radius=10000&key=AIzaSyAgAK9maR3XaoWd-C0paZhABb9rtT_hyi8");
            var pins = new ObservableCollection<Cinema>();

            foreach (Cinema cinema in locationList)
			{
				pins.Add(cinema);

			}
            return pins;
        }

		public string SearchString
		{
            get { return searchString; }
			set
			{
                searchString = value;
				RaisePropertyChanged();
			}
		}

        private void sendSearch(){
            MessagingCenter.Send<ShowCinemasPageViewModel>(this, "SearchHasChanged");
        }
	}
}
