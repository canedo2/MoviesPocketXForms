namespace MoviesPocketXForms.ViewModels
{
    using Base;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using Models;
    using Providers;
    using Xamarin.Forms;
    using Services;
	using System.Threading.Tasks;
    using System.Windows.Input;
	using System.Linq;


	public class MainPageViewModel: BaseViewModel
    {
        private ObservableCollection<MyMedia> items;
        private IWebApiProvider webApiProvider;
        private INavigationService navigationService;
        public ICommand ShowCinemasCommand { get; }
        private MyMedia selectedMyMedia;
        public MainPageViewModel()
        {
            items = new ObservableCollection<MyMedia>();
            webApiProvider = DependencyService.Get<IWebApiProvider>();
            navigationService = DependencyService.Get<INavigationService>();

            ShowCinemasCommand = new Command(async () => await ShowCinemas());
        }

        public async Task Init(){
            IsLoading = true;

            var mediaList = await webApiProvider.GetMediaListAsync();

            foreach (MyMedia m in mediaList){
                m.PosterPath = "https://image.tmdb.org/t/p/w500" + m.PosterPath;
                items.Add(m);

            }

            Items = new ObservableCollection<MyMedia>(mediaList.ToList());              

        }

		public ObservableCollection<MyMedia> Items
		{
			get { return items; }
			set
			{
				items = value;
				RaisePropertyChanged();
			}
		}

        private async Task ShowCinemas(){

            await this.navigationService.NavigateToShowCinemasPage();
        }

        public MyMedia SelectedMyMedia
		{
			get { return selectedMyMedia; }
			set
			{
				selectedMyMedia = value;
				if (selectedMyMedia != null)
				{
                    this.navigationService.NavigateToDetailPage(SelectedMyMedia);
				}
				RaisePropertyChanged();
			}
		}
    }
}
