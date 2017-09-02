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
    using Newtonsoft;

	public class MainPageViewModel: BaseViewModel
    {
        private ObservableCollection<MyMedia> items;
        private IWebApiProvider webApiProvider;
        private INavigationService navigationService;
        private IStorageProvider storageProvider;
        public ICommand ShowCinemasCommand { get; }
        public ICommand ShowFavoritesCommand { get; }
        private MyMedia selectedMyMedia;
        private ObservableCollection<MyMedia> keepApiItems;
        private bool showingFavorites = false;

        public MainPageViewModel()
        {
            items = new ObservableCollection<MyMedia>();
            webApiProvider = DependencyService.Get<IWebApiProvider>();
            navigationService = DependencyService.Get<INavigationService>();
            storageProvider = DependencyService.Get<IStorageProvider>();

            ShowCinemasCommand = new Command(async () => await ShowCinemas());
            ShowFavoritesCommand = new Command(() =>  ShowFavorites());


        }

        public async Task Init(){
            IsLoading = true;
            if(!showingFavorites){
                var mediaList = await webApiProvider.GetMediaListAsync();
				foreach (MyMedia m in mediaList)
				{
					m.PosterPath = "https://image.tmdb.org/t/p/w500" + m.PosterPath;
					items.Add(m);

				}
                Items = new ObservableCollection<MyMedia>(mediaList.ToList());
            }
            else {
                Items = storageProvider.GetFavorites();
            }
            IsLoading = false;
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

        private void ShowFavorites(){
            
            if(!IsLoading){
                IsLoading = true;
				if (showingFavorites == false)
				{
					keepApiItems = Items;
					Items = storageProvider.GetFavorites();
					showingFavorites = true;
				}
				else
				{
					Items = keepApiItems;
					showingFavorites = false;
				}
                IsLoading = false;
			}
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
