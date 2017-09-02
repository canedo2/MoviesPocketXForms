namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Models;
    using System.Windows.Input;
    using Providers;
    using Services;
    using Xamarin.Forms;

    public class DetailPageViewModel : BaseViewModel
    {
        private MyMedia myMedia;
        public string Jaja = "Hola";
        public ICommand SaveFavoriteCommand { get; }
        public IStorageProvider storageProvider;
        private Color favoriteColor = Color.Yellow;

        public DetailPageViewModel()
        {
            storageProvider = DependencyService.Get<IStorageProvider>();
            SaveFavoriteCommand = new Command(() => SaveFavorite());
            favoriteColor = Color.Yellow;	
        }

        public void Init()
        {
            IsLoading = true;

			var favorites = storageProvider.GetFavorites();

			foreach (MyMedia favorite in favorites)
			{
				if (favorite.Title == myMedia.Title && favorite.Overview == myMedia.Overview)
				{
					FavoriteColor = Color.Gray;
					break;
				}
			}
        }

        public void SaveFavorite()
        {
			if (FavoriteColor == Color.Yellow)
			{
				storageProvider.PersistFavorite(myMedia);
				FavoriteColor = Color.LightGray;
			}
			else
			{
				storageProvider.DeleteFavoriteIfExists(myMedia);
				FavoriteColor = Color.Yellow;

			}

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

        public Color FavoriteColor {
            get { return favoriteColor; }
            set
            {
                favoriteColor = value;
                RaisePropertyChanged();
            }

        }
    }
}
