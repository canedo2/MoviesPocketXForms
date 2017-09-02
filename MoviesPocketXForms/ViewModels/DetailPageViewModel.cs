namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Models;
    using System.Windows.Input;
    using Providers;
    using Services;
    using Xamarin.Forms;

    public class DetailPageViewModel: BaseViewModel
    {   
        private MyMedia myMedia;
        public string Jaja = "Hola";
        public ICommand SaveFavoriteCommand { get; }
        public IStorageProvider storageProvider;

        public DetailPageViewModel()
        {
            storageProvider = DependencyService.Get<IStorageProvider>();
			SaveFavoriteCommand = new Command(() => SaveFavorite());

        }

        public void Init()
        {
            IsLoading = true;
        }

        public void SaveFavorite(){
            storageProvider.PersistFavorite(myMedia);
        }

		public MyMedia MyMedia
		{
			get { return myMedia; }
			set
			{
				myMedia = value;
				RaisePropertyChanged();
			}
		}
    }
}
